using Airline.Domain.DataSeeder;

namespace Airline.Infrastructure.Persistence;
public class DbSeeder(AppDbContext appDbContext)
{
    public async Task SeedAsync(bool forceReset = false)
    {
        if (forceReset)
        {
            appDbContext.Tickets.RemoveRange(appDbContext.Tickets);
            appDbContext.Flights.RemoveRange(appDbContext.Flights);
            appDbContext.Passengers.RemoveRange(appDbContext.Passengers);
            appDbContext.AircraftModels.RemoveRange(appDbContext.AircraftModels);
            appDbContext.AircraftFamilys.RemoveRange(appDbContext.AircraftFamilys);
            await appDbContext.SaveChangesAsync();
        }

        if (!forceReset &&
            (appDbContext.AircraftFamilys.Any() ||
             appDbContext.AircraftModels.Any() ||
             appDbContext.Passengers.Any() ||
             appDbContext.Flights.Any() ||
             appDbContext.Tickets.Any()))
        {
            return;
        }

        var seed = new DataFixture();

        await appDbContext.AircraftFamilys.AddRangeAsync(seed.Families);
        await appDbContext.SaveChangesAsync();

        await appDbContext.AircraftModels.AddRangeAsync(seed.Models);
        await appDbContext.SaveChangesAsync();

        await appDbContext.Passengers.AddRangeAsync(seed.Passengers);
        await appDbContext.SaveChangesAsync();

        await appDbContext.Flights.AddRangeAsync(seed.Flights);
        await appDbContext.SaveChangesAsync();

        await appDbContext.Tickets.AddRangeAsync(seed.Tickets);
        await appDbContext.SaveChangesAsync();
    }
}
