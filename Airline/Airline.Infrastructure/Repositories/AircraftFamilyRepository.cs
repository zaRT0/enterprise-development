using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airline.Infrastructure.Repositories;

/// <summary>
/// Repository for managing <see cref="AircraftFamily"/> entities.
/// Implements CRUD operations and provides IQueryable access for advanced queries.
/// </summary>
public class AircraftFamilyRepository(AppDbContext context) : IRepository<AircraftFamily>
{
    /// <summary>
    /// Returns an <see cref="IQueryable{AircraftFamily}"/> for building LINQ queries.
    /// </summary>
    public IQueryable<AircraftFamily> Query() => context.AircraftFamilys.AsQueryable();

    /// <summary>
    /// Retrieves all <see cref="AircraftFamily"/> records from the database.
    /// </summary>
    public async Task<IEnumerable<AircraftFamily>> GetAllAsync() =>
        await context.AircraftFamilys.ToListAsync();

    /// <summary>
    /// Adds a new <see cref="AircraftFamily"/> entity to the database.
    /// </summary>
    /// <param name="entity">The <see cref="AircraftFamily"/> entity to add.</param>
    public async Task AddAsync(AircraftFamily entity)
    {
        await context.AircraftFamilys.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves an <see cref="AircraftFamily"/> by its unique identifier.
    /// </summary>
    public async Task<AircraftFamily?> GetByIdAsync(int id) =>
        await context.AircraftFamilys.FindAsync(id);

    /// <summary>
    /// Finds <see cref="AircraftFamily"/> entities that match the given predicate.
    /// </summary>
    public async Task<IEnumerable<AircraftFamily>> FindAsync(Expression<Func<AircraftFamily, bool>> predicate) =>
        await context.AircraftFamilys.Where(predicate).ToListAsync();

    /// <summary>
    /// Updates an existing <see cref="AircraftFamily"/> entity in the database.
    /// </summary>
    public async Task UpdateAsync(AircraftFamily entity)
    {
        context.AircraftFamilys.Update(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Checks if an <see cref="AircraftFamily"/> exists in the database by its ID.
    /// </summary>
    public async Task<bool> ExistById(int id) =>
        await context.AircraftFamilys.AnyAsync(e => e.Id == id);

    /// <summary>
    /// Deletes an <see cref="AircraftFamily"/> entity from the database by its ID.
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var entity = await context.AircraftFamilys.FindAsync(id) ?? throw new KeyNotFoundException($"AircraftFamily with Id {id} not found.");
        context.AircraftFamilys.Remove(entity);
        await context.SaveChangesAsync();
    }
}
