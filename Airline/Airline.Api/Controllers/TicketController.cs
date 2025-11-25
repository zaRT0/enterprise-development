using Airline.Domain.Interfaces;
using Airline.Dtos.TicketDtos;
using Airline.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Api.Controllers;

[ApiController]
[Route("api/tickets")]
public class TicketController(
    IRepository<Ticket> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<TicketGetDto>>> GetAll()
    {
        var tickets = await repository.GetAllAsync();
        var result = mapper.Map<IEnumerable<TicketGetDto>>(tickets);
        return Ok(result);
    }

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