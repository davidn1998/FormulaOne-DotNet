using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class GetAllDriversHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllDriversQuery, IEnumerable<GetDriverResponse>>
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<GetDriverResponse>> Handle(
        GetAllDriversQuery request,
        CancellationToken cancellationToken
    )
    {
        var drivers = await _unitOfWork.Drivers.All();
        return _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);
    }
}
