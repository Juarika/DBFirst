using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TeamController : BaseApiController
{
    private readonly IUnitOfWork _unitofwork;
    private readonly IMapper _mapper;

    public TeamController(IUnitOfWork unitofwork, IMapper mapper)
    {
        _unitofwork = unitofwork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TeamDto>>> Get()
    {
        var entidad = await _unitofwork.Teams.GetAllAsync();
        return _mapper.Map<List<TeamDto>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TeamDto>> Get(int id)
    {
        var entidad = await _unitofwork.Teams.GetByIdAsync(id);
        if(entidad == null)
        {
            return BadRequest();
        }
        return this._mapper.Map<TeamDto>(entidad);
    } 

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Team>> Post(TeamDto entidadDto)
    {
        var entidad = this._mapper.Map<Team>(entidadDto);
        this._unitofwork.Teams.Add(entidad);
        await _unitofwork.SaveAsync();
        if(entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new {id = entidadDto.Id}, entidadDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeamDto>> Put(int id, [FromBody]TeamDto entidadDto)
    {
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this._mapper.Map<Team>(entidadDto);
        _unitofwork.Teams.Update(entidad);
        await _unitofwork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var entidad = await _unitofwork.Teams.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        _unitofwork.Teams.Remove(entidad);
        await _unitofwork.SaveAsync();
        return NoContent();
    }
}