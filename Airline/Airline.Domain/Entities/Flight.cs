namespace Airline.Domain.Entities;

/// <summary>
/// Represents a flight entity with scheduling, routing, and aircraft assignment information.
/// Contains flight identifiers, codes, departure and arrival locations and times, flight duration, and assigned aircraft model.
/// </summary>
public class Flight
{
    /// <summary>
    /// Unique flight identifier.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Flight code or number used for identification.
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Airport and city of departure including airport code.
    /// </summary>
    public required string DeparturePoint { get; set; }

    /// <summary>
    /// Airport and city of arrival including airport code.
    /// </summary>
    public required string ArrivalPoint { get; set; }

    /// <summary>
    /// Date of departure.
    /// </summary>
    public required DateOnly DepartureDate { get; set; }

    /// <summary>
    /// Date of arrival.
    /// </summary>
    public required DateOnly ArrivalDate { get; set; }

    /// <summary>
    /// Time of departure relative to the departure date.
    /// </summary>
    public required TimeOnly DepartureTime { get; set; }

    /// <summary>
    /// Duration of the flight as a time span.
    /// </summary>
    public required TimeSpan Duration { get; set; }

    /// <summary>
    /// Aircraft model used for this flight.
    /// </summary>
    public required AircraftModel AircraftModel { get; set; }
}
