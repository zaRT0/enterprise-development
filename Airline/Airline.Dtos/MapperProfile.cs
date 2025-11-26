using Airline.Domain.Entities;
using Airline.Dtos.AircraftModelDtos;
using Airline.Dtos.FlightDtos;
using Airline.Dtos.PassengerDtos;
using Airline.Dtos.TicketDtos;
using AutoMapper;

namespace Airline.Dtos;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Flight, FlightGetDto>();
        CreateMap<FlightEditDto, Flight>();

        CreateMap<Ticket, TicketGetDto>();
        CreateMap<TicketEditDto, Ticket>();

        CreateMap<Passenger, PassengerGetDto>();
        CreateMap<PassengerEditDto, Passenger>();

        CreateMap<AircraftModel, AircraftModelGetDto>();
        CreateMap<AircraftModelEditDto, AircraftModel>();
    }
}