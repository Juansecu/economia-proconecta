namespace Proconecta.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Proconecta.Data.Models;

    public interface IUserBL
    {
        Task<IList<User>> Get();
        Task<User> GetById(string id);
        Task<User> Insert(User toInsert);
        Task<User> Update(string id, object toUpdate);
        Task<bool> Delete(string id);
    }
}
