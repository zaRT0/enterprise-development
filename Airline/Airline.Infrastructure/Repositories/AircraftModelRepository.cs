using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airline.Infrastructure.Repositories;

/// <summary>
/// Repository for managing <see cref="AircraftModel"/> entities.
/// Implements CRUD operations and provides IQueryable access for advanced queries.
/// </summary>
public class AircraftModelRepository(AppDbContext context) : IRepository<AircraftModel>
{
    /// <summary>
    /// Returns an <see cref="IQueryable{AircraftModel}"/> for building LINQ queries.
    /// </summary>
    public IQueryable<AircraftModel> Query() => context.AircraftModels.AsQueryable();

    /// <summary>
    /// Retrieves all <see cref="AircraftModel"/> records from the database.
    /// </summary>
    public async Task<IEnumerable<AircraftModel>> GetAllAsync() =>
         await context.AircraftModels.ToListAsync();

    /// <summary>
    /// Adds a new <see cref="AircraftModel"/> entity to the database.
    /// </summary>
    public async Task AddAsync(AircraftModel entity)
    {
        await context.AircraftModels.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves an <see cref="AircraftModel"/> by its unique identifier.
    /// </summary>
    public async Task<AircraftModel?> GetByIdAsync(int id) =>
        await context.AircraftModels.FindAsync(id);

    /// <summary>
    /// Finds <see cref="AircraftModel"/> entities that match the given predicate.
    /// </summary>
    public async Task<IEnumerable<AircraftModel>> FindAsync(Expression<Func<AircraftModel, bool>> predicate) =>
        await context.AircraftModels.Where(predicate).ToListAsync();

    /// <summary>
    /// Updates an existing <see cref="AircraftModel"/> entity in the database.
    /// </summary>
    public async Task UpdateAsync(AircraftModel entity)
    {
        context.AircraftModels.Update(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Checks if an <see cref="AircraftModel"/> exists in the database by its ID.
    /// </summary>
    public async Task<bool> ExistById(int id) =>
        await context.AircraftModels.AnyAsync(x => x.Id == id);

    /// <summary>
    /// Deletes an <see cref="AircraftModel"/> entity from the database by its ID.
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var entity = await context.AircraftModels.FindAsync(id) ?? throw new KeyNotFoundException($"AircraftModel with Id {id} not found.");
        context.AircraftModels.Remove(entity);
        await context.SaveChangesAsync();
    }
}
