using Airline.Domain.DataSeeder;

namespace Airline.Tests;

/// <summary>
/// Contains unit tests for verifying various queries and operations on airline data.
/// Uses the cref to provide consistent sample data for flights, passengers, and tickets.
/// Each test checks a specific business rule or data aggregation relevant to airline management.
/// </summary>
public class AirlineTests(DataSeeder fixture): IClassFixture<DataSeeder>
{
    /// <summary>
    /// Validates that the top five flights are correctly identified based on the number of passengers.
    /// Ensures the result matches expected flight codes and counts in descending order of passenger count.
    /// </summary>
    [Fact]
    public void TopFlightsByPassengerCount()
    {
        var expected = new[]
        {
            (Code: "U6789", Count: 6),
            (Code: "SU1234", Count: 5),
            (Code: "A4567", Count: 3),
            (Code: "DP2468", Count: 2),
            (Code: "Y7890", Count: 2)
        };

        var tickets = fixture.Tickets
            .Where(t => t.Flight != null && t.Passenger != null);

        var query = tickets
            .GroupBy(t => t.Flight.Code)
            .Select(g => new { FlightCode = g.Key, PassengersCount = g.Count() })
            .OrderByDescending(x => x.PassengersCount)
            .ThenBy(x => x.FlightCode)
            .Take(5)
            .ToArray();

        Assert.Equal(expected, query.Select(q => (q.FlightCode, Count: q.PassengersCount)));
    }

    /// <summary>
    /// Confirms that flights with the minimum duration are correctly retrieved.
    /// Checks that the expected flight code is returned for the shortest flight duration.
    /// </summary>
    [Fact]
    public void FlightsWithMinimalDuration()
    {
        var minDuration = fixture.Flights.Min(f => f.Duration);

        var expected = new[] { "Y7890" };

        var queryCodes = fixture.Flights
            .Where(f => f.Duration == minDuration)
            .OrderBy(f => f.Code)
            .Select(f => f.Code)
            .ToArray();

        Assert.Equal(expected, queryCodes);
    }

    /// <summary>
    /// Tests retrieval of passengers with zero baggage weight for a specific flight.
    /// Validates against expected passenger names to ensure accurate filtering by baggage information. 
    /// </summary>
    [Fact]
    public void PassengersWithZeroBaggageWeight()
    {
        var flightCode = "SU1234";

        var expectedPassengers = new[]
        {
            "Petrova Maria Sergeevna",
            "Sidorov Alexey Vladimirovich"
        };

        var queryPassengers = fixture.Tickets
            .Where(t => t.Flight != null
                        && t.Flight.Code == flightCode
                        && (t.TotalBaggageWeight == null || t.TotalBaggageWeight == 0)
                        && t.Passenger != null)
            .Select(t => t.Passenger.FullName)
            .Order()
            .ToArray();

        Assert.Equal(expectedPassengers, queryPassengers);
    }

    /// <summary>
    /// Checks aggregated data about flights and passengers for a specific aircraft model within a given date range.
    /// Verifies one object, includes total flight count, passenger count and massive of flights codes
    /// </summary>
    [Fact]
    public void InformationAboutModelsFlightsPeriod()
    {
        var model = fixture.Models.Single(m => m.Name == "737-800");

        var startDate = new DateTime(2025, 10, 20, 0, 0, 0);
        var endDate = new DateTime(2025, 10, 25, 0, 0, 0);

        // Используем ссылку на модель напрямую, а не Id
        var filteredTickets = fixture.Tickets
            .Where(t => t.Flight != null
                        && t.Flight.AircraftModel == model
                        && t.Flight.DepartureDateTime >= startDate
                        && t.Flight.DepartureDateTime <= endDate
                        && t.Passenger != null)
            .ToList();

        var result = new
        {
            TotalFlights = filteredTickets.Select(t => t.Flight).Distinct().Count(),
            TotalPassengers = filteredTickets.Count,
            FlightCodes = filteredTickets.Select(t => t.Flight.Code).Distinct().ToArray()
        };

        Assert.Equal(1, result.TotalFlights);
        Assert.Equal(5, result.TotalPassengers);
        Assert.Contains("SU1234", result.FlightCodes);
    }


    /// <summary>
    /// Validates filtering of flights by a specified departure and arrival point.
    /// Ensures only flights matching the specified route are returned, matching expected flight codes. 
    /// </summary>
    [Fact]
    public void FlightsFromDepartureToArrival()
    {
        var expectedCodes = new[] { "SU1234" };

        var departurePoint = "Moscow (SVO)";
        var arrivalPoint = "Sochi (AER)";

        var queryCodes = fixture.Flights
            .Where(f => f.DeparturePoint == departurePoint && f.ArrivalPoint == arrivalPoint)
            .OrderBy(f => f.Code)
            .Select(f => f.Code)
            .ToArray();

        Assert.Equal(expectedCodes, queryCodes);
    }
}
