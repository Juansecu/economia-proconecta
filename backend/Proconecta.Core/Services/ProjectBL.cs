namespace Proconecta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Proconecta.Data;
    using Proconecta.Data.Models;

    public class ProjectBL : IProjectBL
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructos
        public ProjectBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Implementations

        public async Task<IList<Project>> Get()
        {
            try
            {
                return await _unitOfWork
                    .ProjectRepo
                    .GetAll()
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Project> GetById(string id)
        {
            try
            {
                return await Task.FromResult(
                    _unitOfWork
                    .ProjectRepo
                    .GetById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Project> Insert(Project toInsert)
        {
            try
            {
                var created = _unitOfWork
                    .ProjectRepo
                    .Add(toInsert);
                await _unitOfWork.CommitAsync();

                return created;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Project> Update(string id, object toUpdate)
        {
            try
            {
                var oldValues = GetEntityById(id);

                var updated = _unitOfWork
                    .ProjectRepo
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
                _unitOfWork.ProjectRepo.Delete(oldValues);
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
        private Project GetEntityById(string id)
        {
            try
            {
                var entity = _unitOfWork
                    .ProjectRepo
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
