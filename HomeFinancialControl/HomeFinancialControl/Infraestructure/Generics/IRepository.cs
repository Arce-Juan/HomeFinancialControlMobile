using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomeFinancialControl.Infraestructure.Generics
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsyncWhitInclude(params Expression<Func<TEntity, object>>[] includes);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
