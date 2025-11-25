namespace Airline.Domain.Entities;

/// <summary>
/// Represents a family of aircraft models.
/// Contains information about the model name and manufacturer.
/// </summary>
public class AircraftFamily
{
    /// <summary>
    /// Unique identifier for the AircraftFamily object
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// The model family name, identifying a series or block of models.
    /// </summary>
    public required string ModelName { get; set; }

    /// <summary>
    /// The name of the manufacturer producing this family of aircraft.
    /// </summary>
    public required string ManufacturerName { get; set; }

    public int? AircraftModelId { get; set; }
}
