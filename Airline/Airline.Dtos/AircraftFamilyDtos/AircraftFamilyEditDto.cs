namespace Airline.Dtos.AircraftFamilyDtos;

/// <summary>
/// Data Transfer Object used for creating or updating an <see cref="Airline.Domain.Entities.AircraftFamily"/>.
/// </summary>
public class AircraftFamilyEditDto
{
    /// <summary>
    /// sets the name of the aircraft model in the family.
    /// </summary>
    public required string ModelName { get; set; }

    /// <summary>
    /// sets the name of the manufacturer of the aircraft family.
    /// </summary>
    public required string ManufacturerName { get; set; }
}
