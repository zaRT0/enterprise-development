namespace Airline.Dtos.PassengerDtos;

/// <summary>
/// Data Transfer Object representing a <see cref="Airline.Domain.Entities.Passenger"/> for read operations.
/// </summary>
public class PassengerGetDto
{
    /// <summary>
    /// Gets the unique identifier of the passenger.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets the passport number of the passenger.
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// Gets the full name of the passenger.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Gets the birth date of the passenger.
    /// </summary>
    public required DateOnly BirthDate { get; set; }
}
