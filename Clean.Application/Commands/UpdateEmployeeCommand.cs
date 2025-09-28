using Clean.Core.Entities;
using Clean.Core.Interfaces;
using MediatR;

namespace Clean.Application.Commands
{
    public record UpdateEmployeeCommand(Employee Employee): IRequest<Employee>;
    public class UpdateEmployeeCommandHandler(IEmployeeRepository context) : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _context = context;
        public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _context.UpdateEmployeeAsync(request.Employee);
        }
    }
}
