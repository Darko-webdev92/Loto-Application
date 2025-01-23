using LotoApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace LotoApp.DAL.Implementations
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class where TId : IEquatable<TId>
    {
       private protected readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task AddRange(List<TEntity> entity)
        {
            await _appDbContext.Set<TEntity>().AddRangeAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Create(TEntity entity)
        {
            await _appDbContext.Set<TEntity>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(TId id)
        {
            var entity = await _appDbContext.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _appDbContext.Remove(entity);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = _appDbContext.Set<TEntity>().AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public async Task<TEntity> GetByID(TId id)
        {
            return await _appDbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetLastOrDefault()
        {
            //IQueryable<TEntity> query = _appDbContext.Set<TEntity>();
            //if (filter != null)
            //{
            //    query = query.Where(filter);
            //}

            //if (includeProperties != null)
            //{
            //    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //    {
            //        query = query.Include(includeProp);
            //    }
            //}

            return _appDbContext.Set<TEntity>().OrderBy(x => x).LastOrDefault();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

    }
}
