using Airline.Domain.DataSeeder;

namespace Airline.Infrastructure.Persistence;
public static class DbSeeder
{
    public static void Seed(this AppDbContext context)
    {

        if (context.AircraftFamilys.Any() || context.AircraftModels.Any() || context.Passengers.Any() || context.Flights.Any() || context.Tickets.Any()) return;

        var seed = new DataFixture();

        context.AircraftFamilys.AddRange(seed.Families);
        context.AircraftModels.AddRange(seed.Models);
        context.Passengers.AddRange(seed.Passengers);
        context.Flights.AddRange(seed.Flights);
        context.Tickets.AddRange(seed.Tickets);
        context.SaveChanges();
    }
}
