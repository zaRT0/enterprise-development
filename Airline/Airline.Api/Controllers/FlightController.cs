using Airline.Domain.Interfaces;
using Airline.Dtos.FlightDtos;
using Airline.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Api.Controllers;

/// <summary>
/// Controller responsible for managing flight data.
/// Provides endpoints to create, read, update, and delete flights.
/// </summary>
[ApiController]
[Route("api/flights")]
public class FlightController(
    IRepository<Flight> repository,
    IMapper mapper
) : ControllerBase
{
    /// <summary>
    /// Retrieves all flights.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<FlightGetDto>>> GetAll()
    {
        var flights = await repository.GetAllAsync();
        var result = mapper.Map<IEnumerable<FlightGetDto>>(flights);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves a flight by unique ID.
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<FlightGetDto>> GetById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null)
            return NotFound();

        var dto = mapper.Map<FlightGetDto>(entity);
        return Ok(dto);
    }

    /// <summary>
    /// Creates a new flight.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<FlightGetDto>> Create([FromBody] FlightEditDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var entity = mapper.Map<Flight>(dto);
        await repository.AddAsync(entity);

        var createdDto = mapper.Map<FlightGetDto>(entity);
        return CreatedAtAction(nameof(GetById), new { id = createdDto.Id }, createdDto);
    }

    /// <summary>
    /// Updates an existing flight by ID.
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Update(int id, [FromBody] FlightEditDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingEntity = await repository.GetByIdAsync(id);
        if (existingEntity == null)
            return NotFound();

        var updatedEntity = mapper.Map(dto, existingEntity);
        updatedEntity.Id = id;
        await repository.UpdateAsync(updatedEntity);

        return NoContent();
    }

    /// <summary>
    /// Deletes a flight by unique ID.
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(204)]
    public async Task<ActionResult> Delete(int id)
    {
        var existingEntity = await repository.GetByIdAsync(id);
        if (existingEntity == null)
            return NoContent();

        await repository.DeleteAsync(id);
        return NoContent();
    }
}