using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airline.Infrastructure.Repositories;

/// <summary>
/// Repository for managing <see cref="Ticket"/> entities.
/// Implements CRUD operations and provides IQueryable access for advanced queries.
/// </summary>
public class TicketRepository(AppDbContext context) : IRepository<Ticket>
{
    /// <summary>
    /// Returns an <see cref="IQueryable{Ticket}"/> for building LINQ queries.
    /// </summary>
    public IQueryable<Ticket> Query() => context.Tickets.AsQueryable();

    /// <summary>
    /// Retrieves all <see cref="Ticket"/> records from the database.
    /// </summary>
    public async Task<IEnumerable<Ticket>> GetAllAsync() =>
        await context.Tickets.ToListAsync();

    /// <summary>
    /// Adds a new <see cref="Ticket"/> entity to the database.
    /// </summary>
    public async Task AddAsync(Ticket entity)
    {
        await context.Tickets.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves a <see cref="Ticket"/> by its unique identifier.
    /// </summary>
    public async Task<Ticket?> GetByIdAsync(int id) =>
        await context.Tickets.FindAsync(id);

    /// <summary>
    /// Finds <see cref="Ticket"/> entities that match the given predicate.
    /// </summary>
    public async Task<IEnumerable<Ticket>> FindAsync(Expression<Func<Ticket, bool>> predicate) =>
        await context.Tickets.Where(predicate).ToListAsync();

    /// <summary>
    /// Updates an existing <see cref="Ticket"/> entity in the database.
    /// </summary>
    public async Task UpdateAsync(Ticket entity)
    {
        context.Tickets.Update(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Checks if a <see cref="Ticket"/> exists in the database by its ID.
    /// </summary>
    public async Task<bool> ExistById(int id) =>
        await context.Tickets.AnyAsync(e => e.Id == id);

    /// <summary>
    /// Deletes a <see cref="Ticket"/> entity from the database by its ID.
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var entity = await context.Tickets.FindAsync(id) ?? throw new KeyNotFoundException($"Ticket with Id {id} not found.");
        context.Tickets.Remove(entity);
        await context.SaveChangesAsync();
    }
}
