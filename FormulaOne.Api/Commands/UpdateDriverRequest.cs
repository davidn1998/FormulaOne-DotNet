using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Commands;

public class UpdateDriverRequest(Guid driverId, UpdateDriverDto driverDto) : IRequest<bool>
{
    public Guid DriverId { get; } = driverId;
    public UpdateDriverDto DriverDto { get; } = driverDto;
}
