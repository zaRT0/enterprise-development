using AutoMapper;
using Airline.Dtos.FlightDtos;
using Airline.Dtos.PassengerDtos;
using Airline.Dtos.TicketDtos;
using Airline.Domain.Entities;

namespace Airline.Dtos;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // Flight mappings
        CreateMap<Flight, FlightGetDto>();
        CreateMap<FlightEditDto, Flight>();

        // Ticket mappings
        CreateMap<Ticket, TicketGetDto>();
        CreateMap<TicketEditDto, Ticket>();

        // Passenger mappings
        CreateMap<Passenger, PassengerGetDto>();
        CreateMap<PassengerEditDto, Passenger>();
    }
}