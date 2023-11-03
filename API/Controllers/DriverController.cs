using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class DriverController : BaseApiController
{
    private readonly IUnitOfWork _unitofwork;
    private readonly IMapper _mapper;

    public DriverController(IUnitOfWork unitofwork, IMapper mapper)
    {
        _unitofwork = unitofwork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<DriverDto>>> Get()
    {
        var entidad = await _unitofwork.Drivers.GetAllAsync();
        return _mapper.Map<List<DriverDto>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<DriverDto>> Get(int id)
    {
        var entidad = await _unitofwork.Drivers.GetByIdAsync(id);
        if(entidad == null)
        {
            return BadRequest();
        }
        return this._mapper.Map<DriverDto>(entidad);
    } 

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Driver>> Post(DriverDto entidadDto)
    {
        var entidad = this._mapper.Map<Driver>(entidadDto);
        this._unitofwork.Drivers.Add(entidad);
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
    public async Task<ActionResult<DriverDto>> Put(int id, [FromBody]DriverDto entidadDto)
    {
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this._mapper.Map<Driver>(entidadDto);
        _unitofwork.Drivers.Update(entidad);
        await _unitofwork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var entidad = await _unitofwork.Drivers.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        _unitofwork.Drivers.Remove(entidad);
        await _unitofwork.SaveAsync();
        return NoContent();
    }
}