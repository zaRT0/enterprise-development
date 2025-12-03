using Airline.Domain.Interfaces;
using Airline.Dtos.TicketDtos;
using Airline.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Api.Controllers;

/// <summary>
/// Controller responsible for handling CRUD operations for tickets.
/// Provides endpoints to create, read, update, and delete tickets.
/// </summary>

[ApiController]
[Route("api/tickets")]
public class TicketController(
    IRepository<Ticket> repository,
    IMapper mapper
) : ControllerBase
{

    /// <summary>
    /// Retrieves all tickets.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<TicketGetDto>>> GetAll()
    {
        var tickets = await repository.GetAllAsync();
        var result = mapper.Map<IEnumerable<TicketGetDto>>(tickets);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves a ticket by its unique identifier.
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<TicketGetDto>> GetById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null)
            return NotFound();

        var dto = mapper.Map<TicketGetDto>(entity);
        return Ok(dto);
    }

    /// <summary>
    /// Creates a new ticket.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<TicketGetDto>> Create([FromBody] TicketEditDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var entity = mapper.Map<Ticket>(dto);
        await repository.AddAsync(entity);

        var createdDto = mapper.Map<TicketGetDto>(entity);
        return CreatedAtAction(nameof(GetById), new { id = createdDto.Id }, createdDto);
    }

    /// <summary>
    /// Updates an existing ticket by ID.
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Update(int id, [FromBody] TicketEditDto dto)
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
    /// Deletes a ticket by its unique identifier.
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