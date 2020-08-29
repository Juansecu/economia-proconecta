namespace Proconecta.Middleware.Enums
{
    using System.ComponentModel;

    public enum ResponseMessagesEnum
    {
        [Description("Ok")]
        Success,
        [Description("Request not found. The specified uri does not exist.")]
        NotFound,
        [Description("Request responded with 'Method Not Allowed'.")]
        MethodNotAllowed,
        [Description("Request no content. The specified uri does not contain any content.")]
        NotContent,
        [Description("Request responded with exceptions.")]
        Exception,
        [Description("Request denied. Unauthorized access.")]
        UnAuthorized,
        [Description("Request responded with validation error(s). Please correct the specified validation errors and try again.")]
        ValidationError,
        [Description("Request cannot be processed. Please contact support.")]
        Unknown,
        [Description("Unhandled Exception occured. Unable to process the request.")]
        Unhandled
    }
}