namespace Proconecta.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;
    using Proconecta.Data.Contexts;

    public class Repository<T> : IRepository<T> where T : class
    {
        #region Internals
        internal ProconectaContext _context;
        internal DbSet<T> _dbSet;
        #endregion

        #region Constructors
        public Repository(ProconectaContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        #endregion

        #region Implementations
        public IQueryable<T> GetAll()
        {
            try
            {
                return _dbSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            try
            {
                return _dbSet.Where(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetById(object Id)
        {
            try
            {
                return _dbSet.Find(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddRange(IEnumerable<T> entities)
        {
            try
            {
                _dbSet.AddRange(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Update(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Update(T internalEntity, object clientEntity)
        {
            try
            {
                _context.Entry(internalEntity).CurrentValues.SetValues(clientEntity);
                _context.Entry(internalEntity).State = EntityState.Modified;
                return internalEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            try
            {
                _dbSet.RemoveRange(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
