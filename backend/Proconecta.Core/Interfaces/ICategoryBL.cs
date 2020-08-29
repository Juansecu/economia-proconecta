namespace Proconecta.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Proconecta.Data.Models;

    public interface ICategoryBL
    {
        Task<IList<Category>> Get();
        Task<Category> GetById(string id);
        Task<Category> Insert(Category toInsert);
        Task<Category> Update(string id, object toUpdate);
        Task<bool> Delete(string id);
    }
}
