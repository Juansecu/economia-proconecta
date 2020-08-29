namespace Proconecta.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Proconecta.Data.Models;

    public interface IPreOrderDetailBL
    {
        Task<IList<PreOrderDetail>> Get();
        Task<PreOrderDetail> GetById(string id);
        Task<PreOrderDetail> Insert(PreOrderDetail toInsert);
        Task<PreOrderDetail> Update(string id, object toUpdate);
        Task<bool> Delete(string id);
    }
}
