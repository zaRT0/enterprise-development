using Airline.Dtos.AircraftModelDtos;
using Airline.Dtos.FlightDtos;

namespace Airline.Dtos.AnalyticsDto;
public class ModelsFlightByPeriodDto
{
    public required AircraftModelGetDto AircraftModelDto { get; set; }

    public required List<FlightGetDto> FlightDtos { get; set; }  
    
}
