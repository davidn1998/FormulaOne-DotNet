using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class AchievementsController(IUnitOfWork unitOfWork, IMapper mapper)
    : BaseController(unitOfWork, mapper)
{
    [HttpGet]
    public async Task<IActionResult> GetAllAchievements()
    {
        var achievements = await _unitOfWork.Achievements.All();

        var result = _mapper.Map<IEnumerable<DriverAchievementResponse>>(achievements);

        return Ok(result);
    }

    [HttpGet("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var driverAchievements = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);

        if (driverAchievements is null)
        {
            return NotFound("Achievements not found");
        }

        var result = _mapper.Map<DriverAchievementResponse>(driverAchievements);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddAchievement(
        [FromBody] CreateDriverAchievementRequest acheivement
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _mapper.Map<Achievement>(acheivement);

        await _unitOfWork.Achievements.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(
            nameof(GetDriverAchievements),
            new { driverId = result.DriverId },
            result
        );
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAchievement(
        [FromBody] UpdateDriverAchievementRequest achievement
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _mapper.Map<Achievement>(achievement);

        await _unitOfWork.Achievements.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    [HttpDelete("{driverId:guid}")]
    public async Task<IActionResult> DeleteAchievement(Guid driverId)
    {
        var driverAchievements = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);

        if (driverAchievements is null)
        {
            return NotFound();
        }

        await _unitOfWork.Achievements.Delete(driverId);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}
