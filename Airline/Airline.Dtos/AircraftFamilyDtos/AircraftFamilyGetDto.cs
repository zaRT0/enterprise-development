namespace Airline.Dtos.AircraftFamilyDtos;

/// <summary>
/// Data Transfer Object representing an <see cref="Airline.Domain.Entities.AircraftFamily"/> for read operations.
/// </summary>
public class AircraftFamilyGetDto
{
    /// <summary>
    /// Gets the unique identifier of the aircraft family.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets the name of the aircraft model in the family.
    /// </summary>
    public required string ModelName { get; set; }

    /// <summary>
    /// Gets the name of the manufacturer of the aircraft family.
    /// </summary>
    public required string ManufacturerName { get; set; } 
}
