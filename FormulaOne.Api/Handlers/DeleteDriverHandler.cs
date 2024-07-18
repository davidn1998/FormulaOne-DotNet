using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class DeleteDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteDriverRequest, bool>
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;

    public async Task<bool> Handle(DeleteDriverRequest request, CancellationToken cancellationToken)
    {
        var driver = await _unitOfWork.Drivers.GetById(request.DriverId);

        if (driver is null)
            return false;

        await _unitOfWork.Drivers.Delete(request.DriverId);
        await _unitOfWork.CompleteAsync();

        return true;
    }
}
