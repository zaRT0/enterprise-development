using Airline.Domain.Interfaces;
using Airline.Dtos.PassengerDtos;
using Airline.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Api.Controllers;

/// <summary>
/// Controller responsible for managing passenger data.
/// Provides endpoints to create, read, update, and delete passengers.
/// </summary>
[ApiController]
[Route("api/passengers")]
public class PassengerController(
    IRepository<Passenger> repository,
    IMapper mapper
) : ControllerBase
{
    /// <summary>
    /// Retrieves all passengers.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<PassengerGetDto>>> GetAll()
    {
        var passengers = await repository.GetAllAsync();
        var result = mapper.Map<IEnumerable<PassengerGetDto>>(passengers);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves a passenger by unique ID.
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<PassengerGetDto>> GetById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null)
            return NotFound();

        var dto = mapper.Map<PassengerGetDto>(entity);
        return Ok(dto);
    }

    /// <summary>
    /// Creates a new passenger.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<PassengerGetDto>> Create([FromBody] PassengerEditDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var entity = mapper.Map<Passenger>(dto);
        await repository.AddAsync(entity);

        var createdDto = mapper.Map<PassengerGetDto>(entity);
        return CreatedAtAction(nameof(GetById), new { id = createdDto.Id }, createdDto);
    }

    /// <summary>
    /// Updates an existing passenger by ID.
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Update(int id, [FromBody] PassengerEditDto dto)
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
    /// Deletes a passenger by unique ID.
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Delete(int id)
    {
        var existingEntity = await repository.GetByIdAsync(id);
        if (existingEntity == null)
            return NotFound();

        await repository.DeleteAsync(id);
        return NoContent();
    }
}
