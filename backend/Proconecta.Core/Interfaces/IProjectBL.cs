namespace Proconecta.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Proconecta.Data.Models;

    public interface IProjectBL
    {
        Task<IList<Project>> Get();
        Task<Project> GetById(string id);
        Task<Project> Insert(Project toInsert);
        Task<Project> Update(string id, object toUpdate);
        Task<bool> Delete(string id);
    }
}
