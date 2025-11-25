using System.Linq.Expressions;

namespace Airline.Domain.Interfaces;
public interface IRepository<T> where T : class
{
    public Task AddAsync(T entity);

    public Task<T?> GetByIdAsync(int id);

    public Task<IEnumerable<T>> GetAllAsync();

    public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    public Task UpdateAsync(T entity);

    public Task<bool> ExistById(int id);

    public Task DeleteAsync(int id);

    public Task SaveChangesAsync();
}
