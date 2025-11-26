using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airline.Infrastructure.Repositories;
public class PassengerRepository(AppDbContext context) : IRepository<Passenger>
{
    public IQueryable<Passenger> Query() => context.Passengers.AsQueryable();
    public async Task<IEnumerable<Passenger>> GetAllAsync() =>
        await context.Passengers.ToListAsync();

    public async Task AddAsync(Passenger entity)
    {
        await context.Passengers.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task<Passenger?> GetByIdAsync(int id) =>
        await context.Passengers.FindAsync(id);

    public async Task<IEnumerable<Passenger>> FindAsync(Expression<Func<Passenger, bool>> predicate) =>
        await context.Passengers.Where(predicate).ToListAsync();

    public async Task UpdateAsync(Passenger entity)
    {
        context.Passengers.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistById(int id) =>
        await context.Passengers.AnyAsync(e => e.Id == id);

    public async Task DeleteAsync(int id)
    {
        var entity = await context.Passengers.FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Passenger with Id {id} not found.");
        }

        context.Passengers.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync() =>
        await context.SaveChangesAsync();
}
