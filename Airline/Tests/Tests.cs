namespace AirlineTests;

/// <summary>
/// Contains unit tests for verifying various queries and operations on airline data.
/// Uses the cref to provide consistent sample data for flights, passengers, and tickets.
/// Each test checks a specific business rule or data aggregation relevant to airline management.
/// </summary>
public class AirlineTests(TestsDataFixture fixture): IClassFixture<TestsDataFixture>
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
            .GroupBy(t => t.Flight.Id)
            .Select(g =>
            {
                var flight = fixture.Flights.Single(f => f.Id == g.Key);
                return new { Flight = flight, PassengersCount = g.Count() };
            })
            .OrderByDescending(x => x.PassengersCount)
            .ThenBy(x => x.Flight.Code)
            .Take(5)
            .ToArray();

        Assert.Equal(expected.Length, query.Length);

        for (var i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i].Code, query[i].Flight.Code);
            Assert.Equal(expected[i].Count, query[i].PassengersCount);
        }
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
    public void PassangersWithZeroBaggageWeight()
    {
        var flightId = 1;

        var expectedPassengers = new[]
        {
            "Petrova Maria Sergeevna",
            "Sidorov Alexey Vladimirovich"
        }.OrderBy(x => x).ToArray();

        var queryPassengers = fixture.Tickets
            .Where(t => t.Flight.Id == flightId && t.TotalBaggageWeight == null)
            .Select(t => t.Passenger.FullName)
            .OrderBy(name => name)
            .ToArray();

        Assert.Equal(expectedPassengers, queryPassengers);
    }

    /// <summary>
    /// Checks aggregated data about flights and passengers for a specific aircraft model within a given date range.
    /// Verifies total flight count, passenger count, and total baggage weight match expected values.
    /// 
    /// </summary>
    [Fact]
    public void InformationAboutModelsFlightsPeriod()
    {
        var model = fixture.Models.Single(m => m.Name == "737-800");

        var startDate = new DateOnly(2025, 10, 20);
        var endDate = new DateOnly(2025, 10, 25);

        var flights = fixture.Flights
            .Where(f => f.AircraftModel.Id == model.Id 
                        && f.DepartureDate >= startDate 
                        && f.DepartureDate <= endDate)
            .ToArray();

        var tickets = fixture.Tickets
            .Where(t => flights.Any(f => f.Id == t.Flight?.Id))
            .ToArray();

        var totalFlights = flights.Length;
        var totalPassengers = tickets.Length;
        var totalBaggageWeight = tickets.Sum(t => t.TotalBaggageWeight ?? 0);

        Assert.Equal(1, totalFlights);
        Assert.Equal(5, totalPassengers);
        Assert.Equal(66.5f, totalBaggageWeight);
    }

    /// <summary>
    /// Validates filtering of flights by a specified departure and arrival point.
    /// Ensures only flights matching the specified route are returned, matching expected flight codes. 
    /// </summary>
    [Fact]
    public void FlightsFromDepartureToArrival()
    {
        var expectedCodes = new[] { "SU1234" };

        var queryCodes = fixture.Flights
            .Where(f => f.DeparturePoint == "Moscow (SVO)" && f.ArrivalPoint == "Sochi (AER)")
            .OrderBy(f => f.Code)
            .Select(f => f.Code)
            .ToArray();

        Assert.Equal(expectedCodes, queryCodes);
    }
}
