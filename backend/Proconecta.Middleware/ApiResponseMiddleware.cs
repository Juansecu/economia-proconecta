namespace Proconecta.Middleware
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;
    using Proconecta.Middleware.Enums;
    using Proconecta.Middleware.Extensions;
    using Proconecta.Middleware.Filters;

    public class ApiResponseMiddleware
    {
        #region Attributes
        private readonly RequestDelegate _next;
        #endregion

        #region Constructors
        public ApiResponseMiddleware(RequestDelegate next) => _next = next;
        #endregion

        #region Invokers
        public async Task InvokeAsync(HttpContext context)
        {
            if (IsSwagger(context))
                await _next(context);
            else if (IsApi(context))
            {
                // var request = await FormatRequest(context.Request);

                var originalBodyStream = context.Response.Body;

                using var bodyStream = new MemoryStream();

                try
                {
                    context.Response.Body = bodyStream;

                    await _next.Invoke(context);

                    var ModelState = context.Features.Get<ModelStateFeature>()?.ModelState;

                    if (ModelState != null && !ModelState.IsValid)
                        throw new ApiException(ModelState.AllErrors());

                    context.Response.Body = originalBodyStream;
                    if (context.Response.StatusCode == (int)HttpStatusCode.OK
                        || context.Response.StatusCode == (int)HttpStatusCode.Created
                        || context.Response.StatusCode == (int)HttpStatusCode.Accepted)
                    {
                        var bodyAsText = await FormatResponse(bodyStream);
                        await HandleSuccessRequestAsync(context, bodyAsText, context.Response.StatusCode);
                    }
                    else
                    {
                        await HandleNotSuccessRequestAsync(context, context.Response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(context, ex);
                    bodyStream.Seek(0, SeekOrigin.Begin);
                    await bodyStream.CopyToAsync(originalBodyStream);
                }

            }
            else
            {
                await _next(context);
            }
        }
        #endregion

        #region Private Methods / Helpers

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Seek(0, SeekOrigin.Begin);

            return $"{request.Method} {request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private async Task<string> FormatResponse(Stream bodyStream)
        {
            bodyStream.Seek(0, SeekOrigin.Begin);
            var plainBodyText = await new StreamReader(bodyStream).ReadToEndAsync();
            bodyStream.Seek(0, SeekOrigin.Begin);

            return plainBodyText;
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ApiError apiError = null;
            int code = 0;

            if (exception is ApiException)
            {
                var ex = exception as ApiException;
                if (ex.IsModelValidatonError)
                {
                    apiError = new ApiError(ResponseMessagesEnum.ValidationError.GetDescription(), ex.Errors)
                    {
                        ReferenceErrorCode = ex.ReferenceErrorCode,
                        ReferenceDocumentLink = ex.ReferenceDocumentLink,
                    };
                }
                else
                {
                    apiError = new ApiError(ex.Message)
                    {
                        ReferenceErrorCode = ex.ReferenceErrorCode,
                        ReferenceDocumentLink = ex.ReferenceDocumentLink,
                    };
                }

                code = ex.StatusCode;
                context.Response.StatusCode = code;

            }
            else if (exception is UnauthorizedAccessException)
            {
                apiError = new ApiError(ResponseMessagesEnum.UnAuthorized.GetDescription());
                code = (int)HttpStatusCode.Unauthorized;
                context.Response.StatusCode = code;
            }
            else
            {

                var exceptionMessage = ResponseMessagesEnum.Unhandled.GetDescription();
#if !DEBUG
                var message = exceptionMessage;
                string stackTrace = null;
#else
                var message = $"{ exceptionMessage } { exception.GetBaseException().Message }";
                string stackTrace = exception.StackTrace;
#endif

                apiError = new ApiError(message) { Details = stackTrace };
                code = (int)HttpStatusCode.InternalServerError;
                context.Response.StatusCode = code;
            }

            var jsonString = ConvertToJSONString(GetErrorResponse(code, apiError));

            var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
            context.Response.ContentType = "application/json";
            context.Response.ContentLength = encoding.GetByteCount(jsonString);
            return context.Response.WriteAsync(jsonString);
        }

        private Task HandleNotSuccessRequestAsync(HttpContext context, int code)
        {
            ApiError apiError;

            if (code == (int)HttpStatusCode.NotFound)
                apiError = new ApiError(ResponseMessagesEnum.NotFound.GetDescription());
            else if (code == (int)HttpStatusCode.NoContent)
                apiError = new ApiError(ResponseMessagesEnum.NotContent.GetDescription());
            else if (code == (int)HttpStatusCode.MethodNotAllowed)
                apiError = new ApiError(ResponseMessagesEnum.MethodNotAllowed.GetDescription());
            else
                apiError = new ApiError(ResponseMessagesEnum.Unknown.GetDescription());

            context.Response.StatusCode = code;

            var jsonString = ConvertToJSONString(GetErrorResponse(code, apiError));

            var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
            context.Response.ContentType = "application/json";
            context.Response.ContentLength = encoding.GetByteCount(jsonString);
            return context.Response.WriteAsync(jsonString);
        }

        private Task HandleSuccessRequestAsync(HttpContext context, object body, int code)
        {
            string jsonString;

            var bodyText = !body.ToString().IsValidJson()
                ? ConvertToJSONString(body)
                : body.ToString();

            dynamic bodyContent = JsonConvert.DeserializeObject<dynamic>(bodyText);
            // Type type = bodyContent?.GetType();

            jsonString = ConvertToJSONString(code, bodyContent);

            var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
            context.Response.ContentType = "application/json";
            context.Response.ContentLength = encoding.GetByteCount(jsonString);
            return context.Response.WriteAsync(jsonString);
        }

        private string ConvertToJSONString(int code, object content)
        {
            return JsonConvert.SerializeObject(new ApiResponse(
                ResponseMessagesEnum.Success.GetDescription(),
                content,
                code), JSONSettings());
        }

        private string ConvertToJSONString(ApiResponse apiResponse)
            => JsonConvert.SerializeObject(apiResponse, JSONSettings());

        private string ConvertToJSONString(object rawJSON)
            => JsonConvert.SerializeObject(rawJSON, JSONSettings());

        private bool IsApi(HttpContext context)
           => context.Request.Path.StartsWithSegments("/api");

        private bool IsSwagger(HttpContext context)
            => context.Request.Path.StartsWithSegments("/swagger");

        private JsonSerializerSettings JSONSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter> { new StringEnumConverter() },
                NullValueHandling = NullValueHandling.Ignore,
            };
        }

        private ApiResponse GetErrorResponse(int code, ApiError apiError)
            => new ApiResponse(code, apiError);
        #endregion
    }
}
