using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class DriversController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
    : BaseController(unitOfWork, mapper)
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAllDrivers()
    {
        var query = new GetAllDriversQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetDriver(Guid id)
    {
        var query = new GetDriverQuery(id);
        var result = await _mediator.Send(query);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _mapper.Map<Driver>(driver);

        await _unitOfWork.Drivers.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriver), new { id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _mapper.Map<Driver>(driver);

        await _unitOfWork.Drivers.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    [HttpDelete("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var driver = await _unitOfWork.Drivers.GetById(driverId);

        if (driver is null)
        {
            return NotFound();
        }

        await _unitOfWork.Drivers.Delete(driverId);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}
