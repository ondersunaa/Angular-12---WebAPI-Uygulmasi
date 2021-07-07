using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KargoAPI.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        void Remove(TEntity entity);

        TEntity Update(TEntity entity);

    }
}
