using Clean.Core.Entities;
using Clean.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Queries
{
    public record GetEmployeeById(Guid employeeId): IRequest<Employee>;

    public class GetEmployeeByIdHandler(IEmployeeRepository context) : IRequestHandler<GetEmployeeById, Employee>
    {
        private readonly IEmployeeRepository _context = context;
        public async Task<Employee> Handle(GetEmployeeById request, CancellationToken cancellationToken)
        {
            return await _context.GetEmployeeByIdAsync(request.employeeId);
        }
    }
}
