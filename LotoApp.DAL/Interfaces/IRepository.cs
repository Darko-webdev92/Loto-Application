using System.Linq.Expressions;

namespace LotoApp.DAL.Interfaces
{
    public interface IRepository<TEntity, TId>
    {
        TEntity GetById(TId id);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
    