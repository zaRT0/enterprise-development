using System.Linq.Expressions;

namespace Airline.Domain.Interfaces;

/// <summary>
/// Generic repository interface providing basic CRUD operations for an entity of type <typeparamref name="T"/>.
/// </summary>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Returns an <see cref="IQueryable{T}"/> to allow querying the entity set.
    /// </summary>
    public IQueryable<T> Query();

    /// <summary>
    /// Adds a new entity to the repository asynchronously.
    /// </summary>
    public Task AddAsync(T entity);

    /// <summary>
    /// Retrieves an entity by its unique identifier asynchronously.
    /// </summary>
    public Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves all entities from the repository asynchronously.
    /// </summary>
    public Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Finds entities that satisfy the specified predicate asynchronously.
    /// </summary>
    public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Updates an existing entity in the repository asynchronously.
    /// </summary>
    public Task UpdateAsync(T entity);

    /// <summary>
    /// Checks whether an entity with the specified identifier exists asynchronously.
    /// </summary>
    public Task<bool> ExistById(int id);

    /// <summary>
    /// Deletes an entity with the specified identifier asynchronously.
    /// </summary>
    public Task DeleteAsync(int id);

}
