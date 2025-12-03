using Airline.Domain.Entities;
using Airline.Dtos.AircraftFamilyDtos;
using Airline.Dtos.AircraftModelDtos;
using Airline.Dtos.FlightDtos;
using Airline.Dtos.PassengerDtos;
using Airline.Dtos.TicketDtos;
using AutoMapper;

namespace Airline.Dtos;

/// <summary>
/// AutoMapper profile defining mappings between domain entities and DTOs.
/// </summary>
public class MapperProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MapperProfile"/> class
    /// and configures all entity-to-DTO and DTO-to-entity mappings.
    /// </summary>
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

        CreateMap<AircraftFamily, AircraftFamilyGetDto>();
        CreateMap<AircraftModel, AircraftModelGetDto>();
    }
}