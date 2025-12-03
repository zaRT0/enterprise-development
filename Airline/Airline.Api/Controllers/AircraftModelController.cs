using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Dtos.AircraftModelDtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Api.Controllers;

/// <summary>
/// Controller responsible for managing aircraft models. 
/// Provides endpoints to retrieve all models or a specific model by ID.
/// </summary>
[ApiController]
[Route("api/aircraft-models")]
public class AircraftModelController(
        IRepository<AircraftModel> repository,
        IMapper mapper
    ) : ControllerBase
{

    /// <summary>
    /// Retrieves all aircraft models.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<AircraftModelGetDto>>> GetAll()
    {
        var models = await repository.GetAllAsync();
        var result = mapper.Map<List<AircraftModelGetDto>>(models);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves a specific aircraft model by its unique ID.
    /// </summary>
    /// <param name="id">The ID of the aircraft model.</param>
    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<AircraftModelGetDto>> GetById(int id)
    {
        var model = await repository.GetByIdAsync(id);
        if (model == null)
            return NotFound();

        var result = mapper.Map<AircraftModelGetDto>(model);
        return Ok(result);
    }
}
