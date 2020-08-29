namespace Proconecta.Middleware
{
    using Newtonsoft.Json;

    public class ValidationError
    {
        #region Properties
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }
        public string Message { get; }
        #endregion

        #region Constructors
        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
        #endregion
    }
}
