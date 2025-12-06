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

/// <summary>
/// Controller providing analytical endpoints for flights, passengers, and aircraft models.
/// </summary>
[ApiController]
[Route("api/analytics")]
public class AnalyticsController(
    IRepository<Ticket> ticketRepo,
    IRepository<Flight> flightRepo,
    IMapper mapper
) : ControllerBase
{
    /// <summary>
    /// Returns the top 5 flights by passenger count.
    /// </summary>
    [HttpGet("top-flights-by-passenger-count")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<FlightsByPassengerCountDto>>> GetTopFlightsByPassengerCount()
    {
        var topFlights = (await ticketRepo.Query()
            .Include(t => t.Flight)
            .Where(t => t.Flight != null)
            .GroupBy(t => t.Flight!)
            .Select(g => new
        {
            Flight = g.Key,
            PassengerCount = g.Count()
        })
        .OrderByDescending(x => x.PassengerCount)
        .ThenBy(x => x.Flight.Code)
        .Take(5)
        .ToListAsync())
        .Select(x => new FlightsByPassengerCountDto
        {
            FlightDto = mapper.Map<FlightGetDto>(x.Flight),
            PassengerCount = x.PassengerCount
        })
        .ToList();

        return Ok(topFlights);  
    }

    /// <summary>
    /// Returns flights of a specific aircraft model within a given period.
    /// </summary>
    [HttpGet("flights-by-model-period")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<ModelsFlightByPeriodDto>> GetFlightsByModelAndPeriod(
    [FromQuery] int modelId,
    [FromQuery] DateTime start,
    [FromQuery] DateTime end)
    {
        var flightsQuery = await flightRepo.Query()
            .Include(f => f.AircraftModel)
            .Where(f => f.AircraftModel.Id == modelId
                        && f.DepartureDateTime >= start
                        && f.DepartureDateTime <= end)
            .OrderBy(f => f.DepartureDateTime)
            .ToListAsync();

        if (flightsQuery.Count == 0)
            return NotFound($"No flights found for AircraftModel ID {modelId} in the given period.");

        var model = flightsQuery.First().AircraftModel;

        var result = new ModelsFlightByPeriodDto
        {
            AircraftModelDto = mapper.Map<AircraftModelGetDto>(flightsQuery),
            FlightDtos = mapper.Map<List<FlightGetDto>>(flightsQuery)
        };

        return Ok(result);
    }

    /// <summary>
    /// Returns flights with the minimal duration.
    /// </summary>
    [HttpGet("flights-min-duration")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<FlightGetDto>>> GetFlightsWithMinimalDuration()
    {
        var minDurationFlights = await flightRepo.Query()
            .OrderBy(f => EF.Functions.DateDiffSecond(f.DepartureDateTime, f.ArrivalDateTime))
            .ThenBy(f => f.Code)
            .ToListAsync();

        if (minDurationFlights.Count == 0)
            return Ok(new List<FlightGetDto>());

        var minDurationSeconds = (minDurationFlights.First().ArrivalDateTime - minDurationFlights.First().DepartureDateTime).TotalSeconds;

        var resultFlights = minDurationFlights
            .Where(f => (f.ArrivalDateTime - f.DepartureDateTime).TotalSeconds == minDurationSeconds)
            .ToList();

        var result = mapper.Map<List<FlightGetDto>>(resultFlights);
        return Ok(result);
    }

    /// <summary>
    /// Returns passengers with zero or missing baggage for a specific flight code.
    /// </summary>
    [HttpGet("passengers-zero-baggage-by-code")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<PassengerGetDto>>> GetPassengersWithZeroBaggageByFlightCode(
     [FromQuery] string flightCode)
    {
        if (string.IsNullOrWhiteSpace(flightCode))
            return BadRequest("Flight code is required.");

        var passengers = (await ticketRepo.Query()
            .Where(t =>
                t.Flight.Code == flightCode &&
                (t.TotalBaggageWeight == null || t.TotalBaggageWeight == 0)
            )
            .Select(t => t.Passenger)
            .Distinct()
            .OrderBy(p => p.FullName)
            .ToListAsync())
            .Select(mapper.Map<PassengerGetDto>);

        return Ok(passengers);
    }

    /// <summary>
    /// Returns flights between a departure and arrival point.
    /// </summary>
    [HttpGet("flights-from-to")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<FlightGetDto>>> GetFlightsFromDepartureToArrival(
    [FromQuery] string departurePoint,
    [FromQuery] string arrivalPoint)
    {
        var filteredFlights = (await flightRepo.Query()
            .Where(f => f.DeparturePoint == departurePoint
                        && f.ArrivalPoint == arrivalPoint)
            .OrderBy(f => f.Code)
            .ToListAsync())
            .Select(mapper.Map<FlightGetDto>);

        return Ok(filteredFlights);
    }
}
