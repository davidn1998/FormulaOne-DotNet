using MediatR;

namespace FormulaOne.Api.Commands;

public class DeleteDriverRequest(Guid driverId) : IRequest<bool>
{
    public Guid DriverId { get; } = driverId;
}
