namespace Proconecta.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Proconecta.Data.Models;

    public interface IProviderBL
    {
        Task<IList<Provider>> Get();
        Task<Provider> GetById(string id);
        Task<Provider> Insert(Provider toInsert);
        Task<Provider> Update(string id, object toUpdate);
        Task<bool> Delete(string id);
    }
}
