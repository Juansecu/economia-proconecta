namespace Proconecta.Middleware
{
    using System;
    using System.Collections.Generic;

    public class ApiException : Exception
    {
        #region Properties
        public int StatusCode { get; set; }
        public bool IsModelValidatonError { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
        public string ReferenceErrorCode { get; set; }
        public string ReferenceDocumentLink { get; set; }

        #endregion

        #region Constructors
        public ApiException(string message,
                    int statusCode = 500,
                    string errorCode = "",
                    string refLink = "") : base(message)
        {
            IsModelValidatonError = false;
            StatusCode = statusCode;
            ReferenceErrorCode = errorCode;
            ReferenceDocumentLink = refLink;
        }

        public ApiException(IEnumerable<ValidationError> errors, int statusCode = 400)
        {
            IsModelValidatonError = true;
            StatusCode = statusCode;
            Errors = errors;
        }

        public ApiException(Exception ex, int statusCode = 500) : base(ex.Message)
        {
            IsModelValidatonError = false;
            StatusCode = statusCode;
        }
        #endregion
    }
}
