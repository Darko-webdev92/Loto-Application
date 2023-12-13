using System.Linq.Expressions;

namespace LotoApp.DAL.Interfaces
{
    public interface IGenericRepository<TEntity, TId> where TEntity : class where TId : IEquatable<TId>
    {
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null);
        Task<TEntity> GetLastOrDefault();
        Task<TEntity> GetByID(TId id);
        Task Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TId id);
        Task AddRange(List<TEntity> entity);
    }
}
