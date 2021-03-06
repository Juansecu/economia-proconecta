﻿namespace Proconecta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Proconecta.Data;
    using Proconecta.Data.Models;

    public class TagBL : ITagBL
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructos
        public TagBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Implementations

        public async Task<IList<Tag>> Get()
        {
            try
            {
                return await _unitOfWork
                    .TagRepo
                    .GetAll()
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Tag> GetById(string id)
        {
            try
            {
                return await Task.FromResult(
                    _unitOfWork
                    .TagRepo
                    .GetById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Tag> Insert(Tag toInsert)
        {
            try
            {
                var created = _unitOfWork
                    .TagRepo
                    .Add(toInsert);
                await _unitOfWork.CommitAsync();

                return created;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Tag> Update(string id, object toUpdate)
        {
            try
            {
                var oldValues = GetEntityById(id);

                var updated = _unitOfWork
                    .TagRepo
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
                _unitOfWork.TagRepo.Delete(oldValues);
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
        private Tag GetEntityById(string id)
        {
            try
            {
                var entity = _unitOfWork
                    .TagRepo
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
