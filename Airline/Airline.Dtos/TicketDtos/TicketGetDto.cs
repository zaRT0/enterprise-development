namespace Airline.Dtos.TicketDtos;

/// <summary>
/// Data Transfer Object representing a <see cref="Airline.Domain.Entities.Ticket"/> for read operations.
/// </summary>
public class TicketGetDto
{
    /// <summary>
    /// Gets the unique identifier of the ticket.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets the ID of the flight associated with the ticket.
    /// </summary>
    public required int FlightId { get; set; }

    /// <summary>
    /// Gets the ID of the passenger associated with the ticket.
    /// </summary>
    public required int PassengerId { get; set; }

    /// <summary>
    /// Gets the seat number assigned to the ticket.
    /// </summary>
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Gets a value indicating whether the ticket includes hand luggage.
    /// </summary>
    public required bool IsHandLuggage { get; set; }

    /// <summary>
    /// Gets the total baggage weight for the ticket, if applicable.
    /// </summary>
    public float? TotalBaggageWeight { get; set; }
}
