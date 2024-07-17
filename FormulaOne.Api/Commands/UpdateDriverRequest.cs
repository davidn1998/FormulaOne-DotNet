using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Commands;

public class UpdateDriverRequest(UpdateDriverDto driverDto) : IRequest<bool>
{
    public UpdateDriverDto DriverDto { get; } = driverDto;
}
