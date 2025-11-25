namespace Airline.Dtos.TicketDtos;
public class TicketEditDto
{
    public required int FlightId { get; set; }

    public required int PassengerId { get; set; }

    public required string SeatNumber { get; set; }

    public required bool IsHandLuggage { get; set; }

    public float? TotalBaggageWeight { get; set; }
}
