using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airline.Infrastructure.Repositories;
public class FlightRepository(AppDbContext context) : IRepository<Flight>
{
    public IQueryable<Flight> Query() => context.Flights.AsQueryable();
    public async Task<IEnumerable<Flight>> GetAllAsync() =>
        await context.Flights.ToListAsync();

    public async Task AddAsync(Flight entity)
    {
        await context.Flights.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task<Flight?> GetByIdAsync(int id) =>
        await context.Flights.FindAsync(id);

    public async Task<IEnumerable<Flight>> FindAsync(Expression<Func<Flight, bool>> predicate) =>
        await context.Flights.Where(predicate).ToListAsync();

    public async Task UpdateAsync(Flight entity)
    {
        context.Flights.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistById(int id) =>
        await context.Flights.AnyAsync(e => e.Id == id);

    public async Task DeleteAsync(int id)
    {
        var entity = await context.Flights.FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Flight with Id {id} not found.");
        }

        context.Flights.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync() =>
        await context.SaveChangesAsync();
}
