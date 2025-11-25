namespace Airline.Dtos.AircraftModelDtos;
public class AircraftModelGetDto
{
    public required int Id { get; set; }    

    public required string Name { get; set; }

    public required int FlightRange { get; set; }

    public required int PassengerCapacity { get; set; }

    public required float CargoCapacity { get; set; }

    public required int ModelFamilyId { get; set; }

    public required string FamilyName { get; set; }
}
