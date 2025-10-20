namespace AirlineTests;

public class AirlineTests(TestsDataFixture fixture): IClassFixture<TestsDataFixture>
{
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

    [Fact]
    public void PassangersWithZeroBaggageWeight()
    {
        var flightId = 1;

        var expectedPassengers = new[]
        {
            "Петрова Мария Сергеевна", //изменение кодировки
            "Сидоров Алексей Владимирович"
        }.OrderBy(x => x).ToArray();

        var queryPassengers = fixture.Tickets
            .Where(t => t.Flight.Id == flightId && t.TotalBaggageWeight == null)
            .Select(t => t.Passenger.FullName)
            .OrderBy(name => name)
            .ToArray();

        Assert.Equal(expectedPassengers, queryPassengers);
    }

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

    [Fact]
    public void FlightsFromDepartureToArrival()
    {
        var expectedCodes = new[] { "SU1234" };

        var queryCodes = fixture.Flights
            .Where(f => f.DeparturePoint == "Москва (SVO)" && f.ArrivalPoint == "Сочи (AER)")
            .OrderBy(f => f.Code)
            .Select(f => f.Code)
            .ToArray();

        Assert.Equal(expectedCodes, queryCodes);
    }
}