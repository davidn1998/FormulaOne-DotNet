using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class GetDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetDriverQuery, GetDriverDto?>
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;

    public async Task<GetDriverDto?> Handle(
        GetDriverQuery request,
        CancellationToken cancellationToken
    )
    {
        var driver = await _unitOfWork.Drivers.GetById(request.DriverId);

        if (driver is null)
            return null;

        return _mapper.Map<GetDriverDto>(driver);
    }
}
