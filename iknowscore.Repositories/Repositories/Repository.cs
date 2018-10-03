using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using iknowscore.DomainModel.Models;
using iknowscore.Repositories.Helpers;
using iknowscore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace iknowscore.Repositories.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly iknowscoreContext DbContext;
        protected readonly DbSet<TEntity> Entities;

        public Repository(iknowscoreContext context)
        {
            DbContext = context;
            Entities = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter, string orderBy, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Entities.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                query = query.SortBy(orderBy);
            }

            if (includeProperties != null && includeProperties.Any())
            {
                query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await FindAllAsync(filter, null);
        }

        public async Task<int> FindCountAsync(Expression<Func<TEntity, bool>> filter)
        {
            var query = Entities.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.CountAsync();
        }

        public async Task<IEnumerable<TEntity>> FindPageAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderBy, int pageIndex, int pageSize)
        {
            var query = orderBy(Entities);
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // get page
            query = query.Skip(pageSize * (pageIndex - 1)).Take(pageSize);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindPageAsync(Expression<Func<TEntity, bool>> filter, string orderBy, int pageIndex, int pageSize)
        {
            var query = Entities.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                query = query.SortBy(orderBy);
            }

            // get page
            query = query.Skip(pageSize * (pageIndex - 1)).Take(pageSize);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties)
        {
            var query = Entities.AsQueryable();

            if (includeProperties != null)
            {
                query = includeProperties(query);
            }

            return await query
                .AsNoTracking()
                .FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await FindFirstAsync(filter, null);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);

            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, TEntity entity)
        {
            Entities.Update(entity);

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entities = await FindAllAsync(filter);
            foreach (var entity in entities)
            {
                Entities.Remove(entity);
            }

            await DbContext.SaveChangesAsync();
        }
    }
}
