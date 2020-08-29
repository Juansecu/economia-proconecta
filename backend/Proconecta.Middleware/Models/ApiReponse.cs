namespace Proconecta.Middleware
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    public class ApiResponse
    {
        #region Properties
        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ApiError ResponseException { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Payload { get; set; }
        #endregion

        #region Constructors
        [JsonConstructor]
        public ApiResponse(string message, object result = null,
            int statusCode = 200)
        {
            StatusCode = statusCode;
            Payload = result;
            Success = true;
        }

        public ApiResponse(int statusCode, ApiError apiError)
        {
            StatusCode = statusCode;
            ResponseException = apiError;
            Success = false;
        }
        #endregion
    }

}
