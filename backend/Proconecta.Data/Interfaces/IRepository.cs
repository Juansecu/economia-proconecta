namespace Proconecta.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        T GetById(object Id);

        IQueryable<T> GetAll();

        IQueryable<T> Query(Expression<Func<T, bool>> filter);

        T Add(T entity);

        void AddRange(IEnumerable<T> entities);

        T Update(T entity);

        T Update(T internalEntity, object clientEntity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);
    }
}
