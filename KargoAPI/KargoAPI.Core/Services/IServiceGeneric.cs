using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KargoAPI.Core.Services
{
   public interface IServiceGeneric<TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task Remove(int id);

        TEntity Update(TEntity entity, int id);
    }
}
