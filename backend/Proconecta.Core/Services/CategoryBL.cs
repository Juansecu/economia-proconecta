namespace Proconecta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Proconecta.Data;
    using Proconecta.Data.Models;

    public class CategoryBL : ICategoryBL
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructos
        public CategoryBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Implementations

        public async Task<IList<Category>> Get()
        {
            try
            {
                return await _unitOfWork
                    .CategoryRepo
                    .GetAll()
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> GetById(string id)
        {
            try
            {
                return await Task.FromResult(
                    _unitOfWork
                    .CategoryRepo
                    .GetById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> Insert(Category toInsert)
        {
            try
            {
                var created = _unitOfWork
                    .CategoryRepo
                    .Add(toInsert);
                await _unitOfWork.CommitAsync();

                return created;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> Update(string id, object toUpdate)
        {
            try
            {
                var oldValues = GetEntityById(id);

                var updated = _unitOfWork
                    .CategoryRepo
                    .Update(oldValues, toUpdate);

                await _unitOfWork.CommitAsync();

                return updated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var oldValues = GetEntityById(id);
                _unitOfWork.CategoryRepo.Delete(oldValues);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private Methods
        private Category GetEntityById(string id)
        {
            try
            {
                var entity = _unitOfWork
                    .CategoryRepo
                    .GetAll()
                    .AsNoTracking()
                    .IgnoreQueryFilters()
                    .Where(w => w.Id == id)
                    .FirstOrDefault();

                if (entity == null)
                    throw new Exception("Invalid data.");

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
