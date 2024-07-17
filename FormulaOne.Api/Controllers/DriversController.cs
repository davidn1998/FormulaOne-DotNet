using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class DriversController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
    : BaseController(unitOfWork, mapper, mediator)
{
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
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverDto driver)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new CreateDriverRequest(driver);
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetDriver), new { id = result.DriverId }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverDto driver)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new UpdateDriverRequest(driver);
        var result = await _mediator.Send(command);

        return result ? NoContent() : BadRequest();
    }

    [HttpDelete("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var command = new DeleteDriverRequest(driverId);
        var result = await _mediator.Send(command);

        return result ? NoContent() : NotFound();
    }
}
