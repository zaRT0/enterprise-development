using Bogus;
using Airline.Dtos.TicketDtos;

namespace Airline.Generator;

public static class Generator
{
    public static List<TicketEditDto> GenerateTickets (int count) =>
        new Faker<TicketEditDto>()
            .RuleFor(x => x.FlightId, f => f.Random.Int(1, 50))
            .RuleFor(x => x.PassengerId, f => f.Random.Int(1, 200))
            .RuleFor(x => x.SeatNumber, f => $"{f.Random.Int(1, 30)}{f.Random.Char('A', 'F')}")
            .RuleFor(x => x.IsHandLuggage, f => f.Random.Bool())
            .RuleFor(x => x.TotalBaggageWeight, f => f.Random.Bool()
                ? f.Random.Float(1, 40)  
                : null                 
            )
            .Generate(count);
}
