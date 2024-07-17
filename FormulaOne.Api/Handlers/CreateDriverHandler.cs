using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class CreateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateDriverRequest, GetDriverDto>
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;

    public async Task<GetDriverDto> Handle(
        CreateDriverRequest request,
        CancellationToken cancellationToken
    )
    {
        var driver = _mapper.Map<Driver>(request.DriverDto);

        await _unitOfWork.Drivers.Add(driver);
        await _unitOfWork.CompleteAsync();

        return _mapper.Map<GetDriverDto>(driver);
    }
}
