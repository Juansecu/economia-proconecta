namespace Proconecta.Data
{
    using System.Threading.Tasks;
    using Proconecta.Data.Models;

    public interface IUnitOfWork
    {
        #region Repositories
        IRepository<Category> CategoryRepo { get; }
        IRepository<PreOrder> PreOrderRepo { get; }
        IRepository<PreOrderDetail> PreOrderDetailRepo { get; }
        IRepository<Product> ProductRepo { get; }
        IRepository<Project> ProjectRepo { get; }
        IRepository<Provider> ProviderRepo { get; }
        IRepository<Review> ReviewRepo { get; }
        IRepository<Tag> TagRepo { get; }
        IRepository<User> UserRepo { get; }
        #endregion

        #region Methods
        void Commit();
        Task CommitAsync();
        void Rollback();
        #endregion
    }
}
