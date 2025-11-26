namespace Airline.Dtos.FlightDtos;

/// <summary>
/// Data Transfer Object representing a <see cref="Airline.Domain.Entities.Flight"/> for read operations.
/// </summary>
public class FlightGetDto
{
    /// <summary>
    /// Gets the unique identifier of the flight.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets the flight code.
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Gets the departure point of the flight.
    /// </summary>
    public required string DeparturePoint { get; set; }

    /// <summary>
    /// Gets the arrival point of the flight.
    /// </summary>
    public required string ArrivalPoint { get; set; }

    /// <summary>
    /// Gets the scheduled departure date and time of the flight.
    /// </summary>
    public required DateTime DepartureDateTime { get; set; }

    /// <summary>
    /// Gets the scheduled arrival date and time of the flight.
    /// </summary>
    public required DateTime ArrivalDateTime { get; set; }

    /// <summary>
    /// Gets the duration of the flight.
    /// </summary>
    public required TimeSpan Duration { get; set; }

    /// <summary>
    /// Gets the ID of the aircraft model assigned to the flight.
    /// </summary>
    public required int AircraftModelId { get; set; }
}
