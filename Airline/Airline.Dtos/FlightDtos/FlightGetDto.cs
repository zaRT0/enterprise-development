namespace Airline.Dtos.FlightDtos;
public class FlightGetDto
{
    public required int Id { get; set; }

    public required string Code { get; set; }

    public required string DeparturePoint { get; set; }

    public required string ArrivalPoint { get; set; }

    public required DateTime DepartureDateTime { get; set; }

    public required DateTime ArrivalDateTime { get; set; }

    public required TimeSpan Duration { get; set; }

    public required int AircraftModelId { get; set; }
}
