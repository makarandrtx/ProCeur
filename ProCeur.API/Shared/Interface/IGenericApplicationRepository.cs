using System.Linq.Expressions;

namespace ProCeur.API.Shared.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdWithTracking<S>(S id);
        Task<T> GetByIdWithoutTracking<S>(S id);
        IQueryable<T> GetAllWithoutTracking();
        IQueryable<T> GetAllWithTracking();
        Task<T> AddAsync(T entity, Guid userId);
        Task DeleteAsync(T entity, Guid userId);
        Task DeleteRangeAsync(IEnumerable<T> entities, Guid userId, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(Guid userId);
        Task SaveChangesAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, Guid userId);
        void Remove(T entity);
        Task<T> AddIfNotExistsAsync(T entity, Guid userId, Expression<Func<T, bool>> predicate = null);
        void DeleteRange(IEnumerable<T> entities, Guid userId);
        Task UpdateRangeAsync(IEnumerable<T> entities, Guid userId, CancellationToken cancellationToken = default);
    }
}
