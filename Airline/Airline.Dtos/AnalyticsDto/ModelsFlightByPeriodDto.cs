using Airline.Dtos.AircraftModelDtos;
using Airline.Dtos.FlightDtos;

namespace Airline.Dtos.AnalyticsDto;

/// <summary>
/// Data Transfer Object representing an aircraft model along with a list of flights
/// that it operates within a specific period.
/// </summary>
public class ModelsFlightByPeriodDto
{
    /// <summary>
    /// Gets or sets the details of the aircraft model.
    /// </summary>
    public required AircraftModelGetDto AircraftModelDto { get; set; }


    /// <summary>
    /// Gets or sets the list of flights associated with the aircraft model within the period.
    /// </summary>
    public required List<FlightGetDto> FlightDtos { get; set; }  
}
