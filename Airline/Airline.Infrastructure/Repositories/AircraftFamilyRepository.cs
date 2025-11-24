using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airline.Infrastructure.Repositories;
public class AircraftFamilyRepository(AppDbContext context) : IRepository<AircraftFamily>
{
    public async Task<IEnumerable<AircraftFamily>> GetAllAsync() =>
        await context.AircraftFamilys.ToListAsync();

    public async Task AddAsync(AircraftFamily entity)
    {
        await context.AircraftFamilys.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task<AircraftFamily?> GetByIdAsync(int id) =>
        await context.AircraftFamilys.FindAsync(id);

    public async Task<IEnumerable<AircraftFamily>> FindAsync(Expression<Func<AircraftFamily, bool>> predicate) =>
        await context.AircraftFamilys.Where(predicate).ToListAsync();

    public async Task UpdateAsync(AircraftFamily entity)
    {
        context.AircraftFamilys.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistById(int id) =>
        await context.AircraftFamilys.AnyAsync(e => e.Id == id);

    public async Task DeleteAsync(int id)
    {
        var entity = await context.AircraftFamilys.FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"AircraftFamily with Id {id} not found.");
        }

        context.AircraftFamilys.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync() =>
        await context.SaveChangesAsync();

}
