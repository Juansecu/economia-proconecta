namespace Proconecta.Data
{
    using System;
    using System.Threading.Tasks;
    using Proconecta.Data.Contexts;
    using Proconecta.Data.Models;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Attributes
        private bool disposed = false;
        private readonly ProconectaContext _context;

        private IRepository<Category> _categoryRepo;
        private IRepository<PreOrder> _preOrderRepo;
        private IRepository<PreOrderDetail> _preOrderDetailRepo;
        private IRepository<Product> _productRepo;
        private IRepository<Project> _projectRepo;
        private IRepository<Provider> _providerRepo;
        private IRepository<Review> _reviewRepo;
        private IRepository<Tag> _tagRepo;
        private IRepository<User> _userRepo;

        #endregion

        #region Properties

        public IRepository<Category> CategoryRepo
        {
            get
            {
                return _categoryRepo ??=
                  new Repository<Category>(_context);
            }
        }

        public IRepository<PreOrder> PreOrderRepo
        {
            get
            {
                return _preOrderRepo ??=
                  new Repository<PreOrder>(_context);
            }
        }

        public IRepository<PreOrderDetail> PreOrderDetailRepo
        {
            get
            {
                return _preOrderDetailRepo ??=
                  new Repository<PreOrderDetail>(_context);
            }
        }

        public IRepository<Product> ProductRepo
        {
            get
            {
                return _productRepo ??=
                  new Repository<Product>(_context);
            }
        }

        public IRepository<Project> ProjectRepo
        {
            get
            {
                return _projectRepo ??=
                  new Repository<Project>(_context);
            }
        }

        public IRepository<Provider> ProviderRepo
        {
            get
            {
                return _providerRepo ??=
                  new Repository<Provider>(_context);
            }
        }

        public IRepository<Review> ReviewRepo
        {
            get
            {
                return _reviewRepo ??=
                  new Repository<Review>(_context);
            }
        }

        public IRepository<Tag> TagRepo
        {
            get
            {
                return _tagRepo ??=
                  new Repository<Tag>(_context);
            }
        }

        public IRepository<User> UserRepo
        {
            get
            {
                return _userRepo ??=
                  new Repository<User>(_context);
            }
        }
        #endregion

        #region Constructors
        public UnitOfWork(ProconectaContext context)
        {
            _context = context;
        }
        #endregion

        #region Implementations
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            _context.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
