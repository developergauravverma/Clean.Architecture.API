using Clean.Core.Entities;
using Clean.Core.Interfaces;
using MediatR;

namespace Clean.Application.Queries
{
    public record GetAllEmployeeQuery(): IRequest<IEnumerable<Employee>>;

    public class GetAllEmployeeQueryHandler(IEmployeeRepository context) : IRequestHandler<GetAllEmployeeQuery, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository _context = context;
        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetAllEmployeesAsync();
        }
    }
}
