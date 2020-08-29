namespace Proconecta.Middleware.Interfaces
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public interface IJsonService
    {
        T Deserialize<T>(string text);

        Task<TResponse> GetSerializedResponse<TResponse>(HttpResponseMessage result,
            NullValueHandling nullValueHandling = NullValueHandling.Include);

        string Serialize<T>(T entity,
            NullValueHandling nullValueHandling = NullValueHandling.Include);
    }
}
