namespace Proconecta.Middleware
{
    using System.Collections.Generic;

    public class ApiError
    {
        #region Properties
        public string Message { get; set; }
        public string Details { get; set; }
        public string ReferenceErrorCode { get; set; }
        public string ReferenceDocumentLink { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
        #endregion

        #region Constructors
        public ApiError(string message)
            => Message = message;

        public ApiError(string message, IEnumerable<ValidationError> validationErrors)
        {
            Message = message;
            ValidationErrors = validationErrors;

        }
        #endregion
    }
}
