using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Commands;

public class CreateDriverRequest(CreateDriverDto driverDto) : IRequest<GetDriverDto>
{
    public CreateDriverDto DriverDto { get; set; } = driverDto;
}
