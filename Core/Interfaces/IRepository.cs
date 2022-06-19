using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync<TKey>(TKey id);
        Task<TEntity> AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entityToDelete);
        Task DeleteRange(IEnumerable<TEntity> entitiesToDelete);
        Task UpdateAsync(TEntity entityToUpdate);
        Task<int> SaveChangesAsync();
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);
        
    }
}
