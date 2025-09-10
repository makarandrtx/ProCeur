using Microsoft.EntityFrameworkCore;
using ProCeur.API.Shared;
using ProCeur.API.Shared.Interface;
using System.Linq.Expressions;

namespace ProCeur.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Retrieves an entity by its ID with tracking.
        public virtual async Task<T> GetByIdWithTracking<S>(S id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Attach(entity);
            return entity;
        }

        // Retrieves an entity by its ID without tracking.
        public virtual async Task<T> GetByIdWithoutTracking<S>(S id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        // Adds a new entity asynchronously.
        public async virtual Task<T> AddAsync(T entity, Guid userId)
        {
            await _dbContext.Set<T>().AddAsync(entity, default);
            await _dbContext.SaveChangesAsync(userId);
            return entity;
        }

        // Adds a new entity if it doesn't already exist, based on the provided predicate.
        public async virtual Task<T> AddIfNotExistsAsync(T entity, Guid userId, Expression<Func<T, bool>> predicate = null)
        {
            var dbSet = _dbContext.Set<T>();
            bool exists = await (predicate != null ? dbSet.AnyAsync(predicate) : dbSet.AnyAsync());
            if (!exists)
            {
                await _dbContext.Set<T>().AddAsync(entity, default);
                await _dbContext.SaveChangesAsync(userId);
                return entity;
            }
            else
            {
                return await dbSet.SingleOrDefaultAsync(predicate);
            }
        }

        // Adds a range of entities asynchronously.
        public async virtual Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, Guid userId)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities, default);
            await _dbContext.SaveChangesAsync(userId);
            return entities;
        }

        // Deletes a single entity asynchronously.
        public async virtual Task DeleteAsync(T entity, Guid userId)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(userId);
        }

        // Removes a single entity without saving changes immediately.
        public virtual void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        // Deletes a range of entities asynchronously.
        public async virtual Task DeleteRangeAsync(IEnumerable<T> entities, Guid userId, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync(userId);
        }

        // Removes a range of entities without saving changes immediately.
        public virtual void DeleteRange(IEnumerable<T> entities, Guid userId)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        // Retrieves all entities without tracking changes.
        public IQueryable<T> GetAllWithoutTracking()
        {
            return _dbContext.Set<T>();
        }

        // Retrieves all entities with tracking.
        public IQueryable<T> GetAllWithTracking()
        {
            return _dbContext.Set<T>().AsTracking();
        }

        // Updates a range of entities asynchronously.
        public async virtual Task UpdateRangeAsync(IEnumerable<T> entities, Guid userId, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync(userId);
        }

        // Saves changes to the database.
        public async virtual Task SaveChangesAsync(Guid userId)
            => await _dbContext.SaveChangesAsync(userId);


        // Saves changes to the database, supports cancellation
        public async virtual Task SaveChangesAsync(Guid userId, CancellationToken cancellationToken)
            => await _dbContext.SaveChangesAsync(userId, cancellationToken);
    }
}
