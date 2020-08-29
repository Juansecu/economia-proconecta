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

        //private IRepository<Entity> _entityRepo;

        #endregion

        #region Properties

        //public IRepository<Entity> AreaRepo
        //{
        //    get
        //    {
        //        return _entityRepo ??=
        //          new Repository<Entity>(_context);
        //    }
        //}

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
