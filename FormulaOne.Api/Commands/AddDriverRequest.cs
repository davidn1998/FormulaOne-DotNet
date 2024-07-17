using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Commands;

public class AddDriverRequest(CreateDriverRequest driverRequest) : IRequest<GetDriverResponse>
{
    public CreateDriverRequest DriverRequest { get; set; } = driverRequest;
}
