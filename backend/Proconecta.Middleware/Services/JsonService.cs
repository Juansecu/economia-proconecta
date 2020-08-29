namespace Proconecta.Middleware.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Proconecta.Middleware.Interfaces;

    public class JsonService : IJsonService
    {
        #region Public Methods

        public T Deserialize<T>(string text)
        {
            T deserializedObject = JsonConvert.DeserializeObject<T>(text);
            return deserializedObject;
        }

        public async Task<TResponse> GetSerializedResponse<TResponse>(
            HttpResponseMessage result,
            NullValueHandling nullValueHandling = NullValueHandling.Include)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = nullValueHandling,
            };

            string response = await result.Content.ReadAsStringAsync();

            TResponse serializedResponse = JsonConvert
                .DeserializeObject<TResponse>(response, jsonSettings);

            return serializedResponse;
        }

        public string Serialize<T>(
            T entity,
            NullValueHandling nullValueHandling = NullValueHandling.Ignore)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = nullValueHandling,
                Formatting = Formatting.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };

            return JsonConvert.SerializeObject(entity, jsonSettings);
        }

        #endregion
    }
}
