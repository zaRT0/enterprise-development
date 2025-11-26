namespace Airline.Dtos.PassengerDtos;

/// <summary>
/// Data Transfer Object used for creating or updating a <see cref="Airline.Domain.Entities.Passenger"/>.
/// </summary>
public class PassengerEditDto
{
    /// <summary>
    /// sets the passport number of the passenger.
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// sets the full name of the passenger.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// sets the birth date of the passenger.
    /// </summary>
    public required DateOnly BirthDate { get; set; }
}
