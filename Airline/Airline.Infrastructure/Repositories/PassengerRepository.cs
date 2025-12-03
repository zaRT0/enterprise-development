using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airline.Infrastructure.Repositories;

/// <summary>
/// Repository for managing <see cref="Passenger"/> entities.
/// Implements CRUD operations and provides IQueryable access for advanced queries.
/// </summary>
public class PassengerRepository(AppDbContext context) : IRepository<Passenger>
{
    /// <summary>
    /// Returns an <see cref="IQueryable{Passenger}"/> for building LINQ queries.
    /// </summary>
    public IQueryable<Passenger> Query() => context.Passengers.AsQueryable();

    /// <summary>
    /// Retrieves all <see cref="Passenger"/> records from the database.
    /// </summary>
    public async Task<IEnumerable<Passenger>> GetAllAsync() =>
        await context.Passengers.ToListAsync();

    /// <summary>
    /// Adds a new <see cref="Passenger"/> entity to the database.
    /// </summary>
    public async Task AddAsync(Passenger entity)
    {
        await context.Passengers.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves a <see cref="Passenger"/> by its unique identifier.
    /// </summary>
    public async Task<Passenger?> GetByIdAsync(int id) =>
        await context.Passengers.FindAsync(id);

    /// <summary>
    /// Finds <see cref="Passenger"/> entities that match the given predicate.
    /// </summary>
    public async Task<IEnumerable<Passenger>> FindAsync(Expression<Func<Passenger, bool>> predicate) =>
        await context.Passengers.Where(predicate).ToListAsync();

    /// <summary>
    /// Updates an existing <see cref="Passenger"/> entity in the database.
    /// </summary>
    public async Task UpdateAsync(Passenger entity)
    {
        context.Passengers.Update(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Checks if a <see cref="Passenger"/> exists in the database by its ID.
    /// </summary>
    public async Task<bool> ExistById(int id) =>
        await context.Passengers.AnyAsync(e => e.Id == id);


    /// <summary>
    /// Deletes a <see cref="Passenger"/> entity from the database by its ID.
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var entity = await context.Passengers.FindAsync(id) ?? throw new KeyNotFoundException($"Passenger with Id {id} not found.");
        context.Passengers.Remove(entity);
        await context.SaveChangesAsync();
    }
}
