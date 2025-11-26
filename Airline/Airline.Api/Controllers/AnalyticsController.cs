using Microsoft.AspNetCore.Mvc;
using Airline.Dtos.AnalyticsDto;
using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Dtos.AircraftModelDtos;
using Airline.Dtos.FlightDtos;
using Airline.Dtos.PassengerDtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
    /// <summary>
    /// Возвращает топ-5 рейсов по количеству пассажиров
    /// </summary>
    [HttpGet("top-flights-by-passenger-count")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<FlightsByPassengerCountDto>>> GetTopFlightsByPassengerCount()
    {
        var tickets = await ticketRepo.GetAllAsync();
        var flights = await flightRepo.GetAllAsync();

        var query = tickets
            .Where(t => t.FlightId != 0)
            .GroupBy(t => t.FlightId)
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

    /// <summary>
    /// Возвращает рейсы по модели самолёта за период
    /// </summary>
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
            .Where(f => f.AircraftModelId == modelId
                        && f.DepartureDateTime >= start
                        && f.DepartureDateTime <= end)
            .OrderBy(f => f.DepartureDateTime)
            .ToList();

        var result = new ModelsFlightByPeriodDto
        {
            AircraftModelDto = mapper.Map<AircraftModelGetDto>(model),
            FlightDtos = mapper.Map<List<FlightGetDto>>(filteredFlights)
        };

        return Ok(result);
    }

    /// <summary>
    /// Возвращает рейсы с минимальной длительностью
    /// </summary>
    [HttpGet("flights-min-duration")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<FlightGetDto>>> GetFlightsWithMinimalDuration()
    {
        var flights = await flightRepo.GetAllAsync();

        if (!flights.Any())
            return Ok(new List<FlightGetDto>());

        var minDuration = flights.Min(f => f.Duration);

        var minDurationFlights = flights
            .Where(f => f.Duration == minDuration)
            .OrderBy(f => f.Code)
            .ToList();

        var result = mapper.Map<List<FlightGetDto>>(minDurationFlights);
        return Ok(result);
    }

    /// <summary>
    /// Возвращает пассажиров с нулевым или отсутствующим багажом на конкретном рейсе
    /// </summary>
    [HttpGet("passengers-zero-baggage-by-code")]
    public async Task<ActionResult<IEnumerable<PassengerGetDto>>> GetPassengersWithZeroBaggageByFlightCode([FromQuery] string flightCode)
    {
        if (string.IsNullOrEmpty(flightCode))
            return BadRequest("Flight code is required.");

        var tickets = await ticketRepo.Query()
            .Include(t => t.Flight)
            .Include(t => t.Passenger)
            .Where(t => t.Flight != null
                        && t.Flight.Code == flightCode
                        && (t.TotalBaggageWeight == null || t.TotalBaggageWeight == 0)
                        && t.Passenger != null)
            .ToListAsync();

        var passengers = tickets
            .Select(t => t.Passenger!)
            .GroupBy(p => p.Id)
            .Select(g => g.First())
            .ToList();

        if (!passengers.Any())
            return NotFound($"No passengers with zero baggage found for flight {flightCode}.");

        var result = mapper.Map<List<PassengerGetDto>>(passengers);
        return Ok(result);
    }
    /// <summary>
    /// Возвращает рейсы между двумя точками
    /// </summary>
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
