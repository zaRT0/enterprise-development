namespace Airline.Dtos.TicketDtos;

/// <summary>
/// Data Transfer Object used for creating or updating a <see cref="Airline.Domain.Entities.Ticket"/>.
/// </summary>
public class TicketEditDto
{
    /// <summary>
    /// sets the ID of the flight associated with the ticket.
    /// </summary>
    public required int FlightId { get; set; }

    /// <summary>
    /// sets the ID of the passenger associated with the ticket.
    /// </summary>
    public required int PassengerId { get; set; }

    /// <summary>
    /// sets the seat number assigned to the ticket.
    /// </summary>
    public required string SeatNumber { get; set; }

    /// <summary>
    /// sets a value indicating whether the ticket includes hand luggage.
    /// </summary>
    public required bool IsHandLuggage { get; set; }

    /// <summary>
    /// sets the total baggage weight for the ticket, if applicable.
    /// </summary>
    public float? TotalBaggageWeight { get; set; }
}
