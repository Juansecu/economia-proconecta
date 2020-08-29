namespace Proconecta.Middleware.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Proconecta.Middleware.Services;

    public static class ApiResponseMiddlewareExtension
    {
        /// <summary>
        /// Custom Api response and handle exceptions responses.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseApiResponseMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware<ApiResponseMiddleware>();
    }
}
