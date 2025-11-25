using Airline.Dtos.FlightDtos;

namespace Airline.Dtos.AnalyticsDto;
public class FlightsByPassengerCountDto
{
    public required FlightGetDto FlightDto { get; set; }

    public required int PassengerCount { get; set; }
}
