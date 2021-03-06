﻿namespace Proconecta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Proconecta.Data;
    using Proconecta.Data.Models;

    public class ProductBL : IProductBL
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructos
        public ProductBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Implementations

        public async Task<IList<Product>> Get()
        {
            try
            {
                return await _unitOfWork
                    .ProductRepo
                    .GetAll()
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> GetById(string id)
        {
            try
            {
                return await Task.FromResult(
                    _unitOfWork
                    .ProductRepo
                    .GetById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> Insert(Product toInsert)
        {
            try
            {
                var created = _unitOfWork
                    .ProductRepo
                    .Add(toInsert);
                await _unitOfWork.CommitAsync();

                return created;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> Update(string id, object toUpdate)
        {
            try
            {
                var oldValues = GetEntityById(id);

                var updated = _unitOfWork
                    .ProductRepo
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
                _unitOfWork.ProductRepo.Delete(oldValues);
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
        private Product GetEntityById(string id)
        {
            try
            {
                var entity = _unitOfWork
                    .ProductRepo
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
