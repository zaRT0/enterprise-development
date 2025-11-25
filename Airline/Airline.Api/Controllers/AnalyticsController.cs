using Microsoft.AspNetCore.Mvc;
using Airline.Dtos.AnalyticsDto;
using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Dtos.AircraftModelDtos;
using Airline.Dtos.FlightDtos;
using Airline.Dtos.PassengerDtos;
using AutoMapper;
namespace Airline.Api.Controllers;

[ApiController]
[Route("api/analytics")]
public class AnalyticsController(
    IRepository<Ticket> ticketRepo,
    IRepository<Flight> flightRepo,
    IRepository<AircraftModel> modelRepo,
    IRepository<Passenger> passengerRepo,
    IMapper mapper
) : ControllerBase
{
    // Топ 5 рейсов по количеству пассажиров
    [HttpGet("top-flights-by-passenger-count")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<FlightsByPassengerCountDto>>> GetTopFlightsByPassengerCount()
    {
        var tickets = await ticketRepo.GetAllAsync();
        var flights = await flightRepo.GetAllAsync();

        var query = tickets
            .Where(t => t.Flight != null && t.Passenger != null)
            .GroupBy(t => t.Flight.Id)
            .Select(g =>
            {
                var flight = flights.First(f => f.Id == g.Key);
                return new FlightsByPassengerCountDto
                {
                    FlightDto = mapper.Map<FlightGetDto>(flight),
                    PassengerCount = g.Count()
                };
            })
            .OrderByDescending(x => x.PassengerCount)
            .ThenBy(x => x.FlightDto.Code)
            .Take(5)
            .ToList();

        return Ok(query);
    }

    // Полёты по модели самолёта за период
    [HttpGet("flights-by-model-period")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<ModelsFlightByPeriodDto>> GetFlightsByModelAndPeriod(
        [FromQuery] int modelId,
        [FromQuery] DateTime start,
        [FromQuery] DateTime end)
    {
        var models = await modelRepo.GetAllAsync();
        var flights = await flightRepo.GetAllAsync();

        var model = models.FirstOrDefault(m => m.Id == modelId);
        if (model == null)
            return NotFound();

        var filteredFlights = flights
            .Where(f => f.AircraftModel != null && f.AircraftModel.Id == modelId
                        && f.DepartureDateTime >= start && f.DepartureDateTime <= end)
            .ToList();

        var result = new ModelsFlightByPeriodDto
        {
            AircraftModelDto = mapper.Map<AircraftModelGetDto>(model),
            FlightDtos = mapper.Map<List<FlightGetDto>>(filteredFlights)
        };

        return Ok(result);
    }

    // Минимальная длительность полётов, возвращаем FlightGetDto по минимальному времени
    [HttpGet("flights-min-duration")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<FlightGetDto>>> GetFlightsWithMinimalDuration()
    {
        var flights = await flightRepo.GetAllAsync();

        var minDuration = flights.Min(f => f.Duration);
        var minDurationFlights = flights
            .Where(f => f.Duration == minDuration)
            .OrderBy(f => f.Code)
            .ToList();

        var result = mapper.Map<List<FlightGetDto>>(minDurationFlights);
        return Ok(result);
    }

    // Пассажиры со 0 весом багажа на конкретном рейсе
    [HttpGet("passengers-zero-baggage")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<PassengerGetDto>>> GetPassengersWithZeroBaggage(
        [FromQuery] int flightId)
    {
        var tickets = await ticketRepo.GetAllAsync();
        var passengers = await passengerRepo.GetAllAsync();

        var filteredPassengers = tickets
            .Where(t => t.Flight.Id == flightId && (t.TotalBaggageWeight == null || t.TotalBaggageWeight == 0))
            .Select(t => t.Passenger)
            .Distinct()
            .ToList();

        var result = mapper.Map<List<PassengerGetDto>>(filteredPassengers);
        return Ok(result);
    }

    [HttpGet("flights-from-to")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<FlightGetDto>>> GetFlightsFromDepartureToArrival(
    [FromQuery] string departurePoint,
    [FromQuery] string arrivalPoint)
    {
        var flights = await flightRepo.GetAllAsync();
        var filteredFlights = flights
            .Where(f => f.DeparturePoint == departurePoint && f.ArrivalPoint == arrivalPoint)
            .OrderBy(f => f.Code)
            .ToList();

        var result = mapper.Map<List<FlightGetDto>>(filteredFlights);
        return Ok(result);
    }
}