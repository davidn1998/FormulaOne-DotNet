using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;

namespace FormulaOne.Api.Controllers;

public class AchievementsController(IUnitOfWork unitOfWork, IMapper mapper)
    : BaseController(unitOfWork, mapper) { }
