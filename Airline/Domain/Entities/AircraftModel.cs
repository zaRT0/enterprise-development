namespace Airline.Domain.Entities;

/// <summary>
/// Describes an individual aircraft model including its specifications and associated family.
/// Contains unique ID, model name, flight range, passenger and cargo capacity, reference to its family.
/// </summary>
public class AircraftModel
{
    /// <summary>
    /// Unique identifier of the aircraft model.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// The official name or designation of the aircraft model
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The family to which this model belongs.
    /// </summary>
    public required AircraftFamily ModelFamily { get; set; }

    /// <summary>
    /// Maximum flight range in kilometers that this aircraft model can cover.
    /// </summary>
    public required int FlightRange { get; set; }

    /// <summary>
    /// Maximum number of passengers that can be carried on this model.
    /// </summary>
    public required int PassengerCapacity { get; set; }

    /// <summary>
    /// Maximum cargo capacity of the aircraft measured in metric tons.
    /// </summary>
    public required float CargoCapacity { get; set; }
}
