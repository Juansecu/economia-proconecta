namespace Proconecta.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Proconecta.Data.Models;

    public interface IProductBL
    {
        Task<IList<Product>> Get();
        Task<Product> GetById(string id);
        Task<Product> Insert(Product toInsert);
        Task<Product> Update(string id, object toUpdate);
        Task<bool> Delete(string id);
    }
}
