using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airline.Infrastructure.Repositories;

/// <summary>
/// Repository for managing <see cref="Flight"/> entities.
/// Implements CRUD operations and provides IQueryable access for advanced queries.
/// </summary>
public class FlightRepository(AppDbContext context) : IRepository<Flight>
{
    /// <summary>
    /// Returns an <see cref="IQueryable{Flight}"/> for building LINQ queries.
    /// </summary>
    public IQueryable<Flight> Query() => context.Flights.AsQueryable();

    /// <summary>
    /// Retrieves all <see cref="Flight"/> records from the database.
    /// </summary>
    public async Task<IEnumerable<Flight>> GetAllAsync() =>
        await context.Flights.ToListAsync();

    /// <summary>
    /// Adds a new <see cref="Flight"/> entity to the database.
    /// </summary>
    public async Task AddAsync(Flight entity)
    {
        await context.Flights.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves a <see cref="Flight"/> by its unique identifier.
    /// </summary>
    public async Task<Flight?> GetByIdAsync(int id) =>
        await context.Flights.FindAsync(id);

    /// <summary>
    /// Finds <see cref="Flight"/> entities that match the given predicate.
    /// </summary>
    public async Task<IEnumerable<Flight>> FindAsync(Expression<Func<Flight, bool>> predicate) =>
        await context.Flights.Where(predicate).ToListAsync();

    /// <summary>
    /// Updates an existing <see cref="Flight"/> entity in the database.
    /// </summary>
    public async Task UpdateAsync(Flight entity)
    {
        context.Flights.Update(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Checks if a <see cref="Flight"/> exists in the database by its ID.
    /// </summary>
    public async Task<bool> ExistById(int id) =>
        await context.Flights.AnyAsync(e => e.Id == id);

    /// <summary>
    /// Deletes a <see cref="Flight"/> entity from the database by its ID.
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var entity = await context.Flights.FindAsync(id) ?? throw new KeyNotFoundException($"Flight with Id {id} not found.");
        context.Flights.Remove(entity);
        await context.SaveChangesAsync();
    }
}
