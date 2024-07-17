using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries;

public class GetDriverQuery(Guid driverId) : IRequest<GetDriverResponse>
{
    public Guid DriverId { get; } = driverId;
}
