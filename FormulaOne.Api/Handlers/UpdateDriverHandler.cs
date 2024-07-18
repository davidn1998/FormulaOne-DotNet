using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class UpdateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateDriverRequest, bool>
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;

    public async Task<bool> Handle(UpdateDriverRequest request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Driver>(request.DriverDto);

        await _unitOfWork.Drivers.Update(request.DriverId, result);
        var success = await _unitOfWork.CompleteAsync();

        return success;
    }
}
