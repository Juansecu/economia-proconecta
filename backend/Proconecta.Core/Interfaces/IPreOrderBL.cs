namespace Proconecta.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Proconecta.Data.Models;

    public interface IPreOrderBL
    {
        Task<IList<PreOrder>> Get();
        Task<PreOrder> GetById(string id);
        Task<PreOrder> Insert(PreOrder toInsert);
        Task<PreOrder> Update(string id, object toUpdate);
        Task<bool> Delete(string id);
    }
}
