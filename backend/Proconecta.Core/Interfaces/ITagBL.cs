namespace Proconecta.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Proconecta.Data.Models;

    public interface ITagBL
    {
        Task<IList<Tag>> Get();
        Task<Tag> GetById(string id);
        Task<Tag> Insert(Tag toInsert);
        Task<Tag> Update(string id, object toUpdate);
        Task<bool> Delete(string id);
    }
}
