using Bogus;
using Airline.Dtos.TicketDtos;

namespace Airline.Generator;

/// <summary>
/// Generates a collection of <see cref="TicketEditDto"/> objects
/// filled with randomized test data using the Bogus library.
/// </summary>
public static class Generator
{
    public static List<TicketEditDto> GenerateTickets (int count) =>
        new Faker<TicketEditDto>()
            .RuleFor(x => x.FlightId, f => f.Random.Int(1, 10))
            .RuleFor(x => x.PassengerId, f => f.Random.Int(1, 23))
            .RuleFor(x => x.SeatNumber, f => $"{f.Random.Int(1, 20)}{f.Random.Char('A', 'F')}")
            .RuleFor(x => x.IsHandLuggage, f => f.Random.Bool())
            .RuleFor(x => x.TotalBaggageWeight, f => f.Random.Bool()
                ? f.Random.Float(1, 40)  
                : null                 
            )
            .Generate(count);
}
