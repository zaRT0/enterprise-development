using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airline.Infrastructure.Repositories;
public class AircraftModelRepository(AppDbContext context) : IRepository<AircraftModel>
{
    public IQueryable<AircraftModel> Query() => context.AircraftModels.AsQueryable();
    public async Task<IEnumerable<AircraftModel>> GetAllAsync() =>
         await context.AircraftModels.ToListAsync();
  
    public async Task AddAsync(AircraftModel entity)
    {
        await context.AircraftModels.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task<AircraftModel?> GetByIdAsync(int id) =>
        await context.AircraftModels.FindAsync(id);

    public async Task<IEnumerable<AircraftModel>> FindAsync(Expression<Func<AircraftModel, bool>> predicate) =>
        await context.AircraftModels.Where(predicate).ToListAsync();

    public async Task UpdateAsync(AircraftModel entity)
    {
        context.AircraftModels.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistById(int id) =>
        await context.AircraftModels.AnyAsync(x => x.Id == id);

    public async Task DeleteAsync(int id)
    {
        var entity = await context.AircraftModels.FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"AircraftModel with Id {id} not found.");

        context.AircraftModels.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync() =>
        await context.SaveChangesAsync();
}
