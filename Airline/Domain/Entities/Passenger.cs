namespace Domain.Entities;
/// <summary>
/// Describes a passenger with personal and identification data.
/// Contains unique ID, passport number, full legal name, and birth date.
/// </summary>
public class Passenger
{
    /// <summary>
    /// Unique identifier for the passenger.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Official passport number for identification.
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// Full name of the passenger (last, first, and middle names).
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Passenger's date of birth.
    /// </summary>
    public required DateOnly BirthDate { get; set; }
}
