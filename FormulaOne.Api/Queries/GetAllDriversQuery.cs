using FormulaOne.Entities;
using MediatR;

namespace FormulaOne.Api.Queries;

public class GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>> { }
