using KargoAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KargoAPI.Core.Repository;
using KargoAPI.Core.UnitOfWork;

namespace KargoAPI.Service.Services
{
    public class ServiceGeneric<TEntity> : IServiceGeneric<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceGeneric(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommmitAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task Remove(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                _repository.Remove(entity);
                await _unitOfWork.CommmitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public TEntity Update(TEntity entity, int id)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Where(predicate);
        }
    }
}
