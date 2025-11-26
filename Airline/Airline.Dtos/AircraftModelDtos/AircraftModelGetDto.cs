namespace Airline.Dtos.AircraftModelDtos;

/// <summary>
/// Data Transfer Object representing an <see cref="Airline.Domain.Entities.AircraftModel"/> for read operations.
/// </summary>
public class AircraftModelGetDto
{
    /// <summary>
    /// Gets the unique identifier of the aircraft model.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets the name of the aircraft model.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets the flight range of the aircraft model in kilometers.
    /// </summary>
    public required int FlightRange { get; set; }

    /// <summary>
    /// Gets the passenger capacity of the aircraft model.
    /// </summary>
    public required int PassengerCapacity { get; set; }

    /// <summary>
    /// Gets the cargo capacity of the aircraft model in tons.
    /// </summary>
    public required float CargoCapacity { get; set; }

    /// <summary>
    /// Gets the identifier of the model family to which the aircraft model belongs.
    /// </summary>
    public required int ModelFamilyId { get; set; }

}
