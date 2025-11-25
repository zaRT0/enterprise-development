namespace Airline.Dtos.PassengerDtos;
public class PassengerGetDto
{
    public required int Id { get; set; }
    
    public required string PassportNumber { get; set; }

    public required string FullName { get; set; }

    public required DateOnly BirthDate { get; set; }
}
