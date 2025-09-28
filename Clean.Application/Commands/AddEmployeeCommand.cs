using Clean.Core.Entities;
using Clean.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Commands
{
    public record AddEmployeeCommand(Employee Employee): IRequest<Employee>;

    public class AddEmployeeCommandHandler(IEmployeeRepository context) : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _context = context;
        public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _context.AddEmployeeAsync(request.Employee);
        }
    }
}
