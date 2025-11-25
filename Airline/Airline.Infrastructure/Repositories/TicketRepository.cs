using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airline.Infrastructure.Repositories;
public class TicketRepository(AppDbContext context) : IRepository<Ticket>
{
    public async Task<IEnumerable<Ticket>> GetAllAsync() =>
        await context.Tickets.ToListAsync();

    public async Task AddAsync(Ticket entity)
    {
        await context.Tickets.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task<Ticket?> GetByIdAsync(int id) =>
        await context.Tickets.FindAsync(id);

    public async Task<IEnumerable<Ticket>> FindAsync(Expression<Func<Ticket, bool>> predicate) =>
        await context.Tickets.Where(predicate).ToListAsync();

    public async Task UpdateAsync(Ticket entity)
    {
        context.Tickets.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistById(int id) =>
        await context.Tickets.AnyAsync(e => e.Id == id);

    public async Task DeleteAsync(int id)
    {
        var entity = await context.Tickets.FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Ticket with Id {id} not found.");
        }

        context.Tickets.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync() =>
        await context.SaveChangesAsync();
}
