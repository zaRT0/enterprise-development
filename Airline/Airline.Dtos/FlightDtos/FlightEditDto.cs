namespace Airline.Dtos.FlightDtos;

/// <summary>
/// Data Transfer Object used for creating or updating a <see cref="Airline.Domain.Entities.Flight"/>.
/// </summary>
public class FlightEditDto
{
    /// <summary>
    ///  sets the flight code.
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// sets the departure point of the flight.
    /// </summary>
    public required string DeparturePoint { get; set; }

    /// <summary>
    /// sets the arrival point of the flight.
    /// </summary>
    public required string ArrivalPoint { get; set; }

    /// <summary>
    /// sets the scheduled departure date and time of the flight.
    /// </summary>
    public required DateTime DepartureDateTime { get; set; }

    /// <summary>
    /// sets the scheduled arrival date and time of the flight.
    /// </summary>
    public required DateTime ArrivalDateTime { get; set; }

    /// <summary>
    /// sets the ID of the aircraft model assigned to the flight.
    /// </summary>
    public required int AircraftModelId { get; set; }
}
