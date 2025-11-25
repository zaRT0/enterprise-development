namespace Airline.Dtos.PassengerDtos;
public class PassengerEditDto
{
    public required string PassportNumber { get; set; }

    public required string FullName { get; set; }

    public required DateOnly BirthDate { get; set; }

}
