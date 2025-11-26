using Airline.Dtos.FlightDtos;

namespace Airline.Dtos.AnalyticsDto;

/// <summary>
/// Data Transfer Object representing a flight along with the number of passengers on that flight.
/// </summary>
public class FlightsByPassengerCountDto
{
    /// <summary>
    /// Gets or sets the flight details.
    /// </summary>
    public required FlightGetDto FlightDto { get; set; }

    /// <summary>
    /// Gets or sets the total number of passengers for the flight.
    /// </summary>
    public required int PassengerCount { get; set; }
}
