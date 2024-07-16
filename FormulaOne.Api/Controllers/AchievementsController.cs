using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class AchievementsController(IUnitOfWork unitOfWork, IMapper mapper)
    : BaseController(unitOfWork, mapper)
{
    [HttpGet]
    [Route("{driverId:guid}")]
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
}
