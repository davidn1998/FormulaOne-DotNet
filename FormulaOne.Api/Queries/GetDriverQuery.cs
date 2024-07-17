using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries;

public class GetDriverQuery(Guid driverId) : IRequest<GetDriverDto>
{
    public Guid DriverId { get; } = driverId;
}
