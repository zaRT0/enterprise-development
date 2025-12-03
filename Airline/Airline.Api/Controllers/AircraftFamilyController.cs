using Microsoft.AspNetCore.Mvc;
using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Dtos.AircraftFamilyDtos;
using AutoMapper;

namespace Airline.Api.Controllers;

/// <summary>
/// Controller responsible for managing aircraft families. 
/// Provides endpoints to retrieve all families or a specific family by ID.
/// </summary>
[ApiController]
[Route("api/aircraft-families")]
public class AircraftFamilyController(
        IRepository<AircraftFamily> repository,
        IMapper mapper
    ) : ControllerBase
{

    /// <summary>
    /// Retrieves all aircraft families.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<AircraftFamilyGetDto>>> GetAll()
    {
        var families = await repository.GetAllAsync();
        var result = mapper.Map<List<AircraftFamilyGetDto>>(families);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves a specific aircraft family by its unique ID.
    /// </summary>
    /// <param name="id">The ID of the aircraft family.</param>
    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<AircraftFamilyGetDto>> GetById(int id)
    {
        var family = await repository.GetByIdAsync(id);
        if (family == null)
            return NotFound();

        var result = mapper.Map<AircraftFamilyGetDto>(family);
        return Ok(result);
    }
}
