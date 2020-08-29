namespace Proconecta.Data
{
    using System.Threading.Tasks;
    using Proconecta.Data.Models;

    public interface IUnitOfWork
    {
        #region Repositories
        //IRepository<Entity> EntityRepo { get; }
        #endregion

        #region Methods
        void Commit();
        Task CommitAsync();
        void Rollback();
        #endregion
    }
}
