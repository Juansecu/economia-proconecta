namespace Proconecta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Proconecta.Data;
    using Proconecta.Data.Models;

    public class PreOrderDetailBL : IPreOrderDetailBL
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructos
        public PreOrderDetailBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Implementations

        public async Task<IList<PreOrderDetail>> Get()
        {
            try
            {
                return await _unitOfWork
                    .PreOrderDetailRepo
                    .GetAll()
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PreOrderDetail> GetById(string id)
        {
            try
            {
                return await Task.FromResult(
                    _unitOfWork
                    .PreOrderDetailRepo
                    .GetById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PreOrderDetail> Insert(PreOrderDetail toInsert)
        {
            try
            {
                var created = _unitOfWork
                    .PreOrderDetailRepo
                    .Add(toInsert);
                await _unitOfWork.CommitAsync();

                return created;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PreOrderDetail> Update(string id, object toUpdate)
        {
            try
            {
                var oldValues = GetEntityById(id);

                var updated = _unitOfWork
                    .PreOrderDetailRepo
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
                _unitOfWork.PreOrderDetailRepo.Delete(oldValues);
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
        private PreOrderDetail GetEntityById(string id)
        {
            try
            {
                var entity = _unitOfWork
                    .PreOrderDetailRepo
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
