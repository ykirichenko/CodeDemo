using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iknowscore.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter,
                                            string orderBy,
                                            Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter);

        Task<int> FindCountAsync(Expression<Func<TEntity, bool>> filter);

        Task<IEnumerable<TEntity>> FindPageAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderBy, int pageIndex, int pageSize);

        Task<IEnumerable<TEntity>> FindPageAsync(Expression<Func<TEntity, bool>> filter, string orderBy, int pageIndex, int pageSize);

        Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> filter,
                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties);

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(int id, TEntity entity);

        Task DeleteAsync(Expression<Func<TEntity, bool>> filter);
    }
}
