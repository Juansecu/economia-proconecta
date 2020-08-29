namespace Proconecta.Middleware.Extensions
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public static class StringExtension
    {
        public static bool IsValidJson(this string text)
        {
            text = text.Trim();
            if ((text.StartsWith("{") && text.EndsWith("}")) || // object
                (text.StartsWith("[") && text.EndsWith("]"))) // array
            {
                try
                {
                    var obj = JToken.Parse(text);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}
