using Airline.Domain.DataSeeder;

namespace Airline.Infrastructure.Persistence;

/// <summary>
/// Provides extension methods for seeding the database with initial data.
/// </summary>
public static class DbSeeder
{
    /// <summary>
    /// Seeds the database with initial data if it is empty.
    /// </summary>
    public static void Seed(this AppDbContext context)
    {

        if (context.AircraftFamilys.Any() || context.AircraftModels.Any() || context.Passengers.Any() || context.Flights.Any() || context.Tickets.Any()) return;

        var seed = new DataSeeder();

        context.AircraftFamilys.AddRange(seed.Families);
        context.AircraftModels.AddRange(seed.Models);
        context.Passengers.AddRange(seed.Passengers);
        context.Flights.AddRange(seed.Flights);
        context.Tickets.AddRange(seed.Tickets);
        context.SaveChanges();
    }
}
