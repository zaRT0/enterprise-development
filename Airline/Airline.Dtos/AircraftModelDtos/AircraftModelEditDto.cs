namespace Airline.Dtos.AircraftModelDtos;

/// <summary>
/// Data Transfer Object used for creating or updating an <see cref="Airline.Domain.Entities.AircraftModel"/>.
/// </summary>
public class AircraftModelEditDto
{
    /// <summary>
    /// sets the name of the aircraft model.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// sets the flight range of the aircraft model in kilometers.
    /// </summary>
    public required int FlightRange { get; set; }

    /// <summary>
    /// sets the passenger capacity of the aircraft model.
    /// </summary>
    public required int PassengerCapacity { get; set; }

    /// <summary>
    /// sets the cargo capacity of the aircraft model in tons.
    /// </summary>
    public required float CargoCapacity { get; set; }

    /// <summary>
    /// sets the identifier of the model family to which the aircraft model belongs.
    /// </summary>
    public required int ModelFamilyId { get; set; } 
}
