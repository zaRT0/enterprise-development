namespace Airline.Domain.Entities;

/// <summary>
/// Represents a ticket issued to a passenger for a specific flight.
/// Contains ticket ID, linked flight and passenger, seat, hand luggage flag, baggage weight.
/// </summary>
public class Ticket
{
    /// <summary>
    /// Unique ticket identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Flight associated with this ticket.
    /// </summary>
    public required Flight Flight { get; set; }

    /// <summary>
    /// Identifier of the flight associated with this ticket.
    /// Serves as a foreign key to the Flight entity.
    /// </summary>
    public int FlightId { get; set; }

    /// <summary>
    /// Identifier of the passenger who owns this ticket.
    /// Serves as a foreign key to the Passenger entity.
    /// </summary>
    public int PassengerId { get; set; }

    /// <summary>
    /// Passenger who holds this ticket.
    /// </summary>
    public required Passenger Passenger { get; set; }

    /// <summary>
    /// Seat number assigned to the passenger on the flight.
    /// </summary>
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Indicates whether the luggage qualifies as hand luggage.
    /// </summary>
    public required bool IsHandLuggage { get; set; }

    /// <summary>
    /// Total baggage weight in kilograms, if present.
    /// </summary>
    public float? TotalBaggageWeight { get; set; }
}
