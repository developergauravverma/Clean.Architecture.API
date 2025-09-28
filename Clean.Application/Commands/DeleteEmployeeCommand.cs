using Clean.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Commands
{
    public record DeleteEmployeeCommand(Guid id): IRequest<bool>;

    public class DeleteEmployeeCommandHandler(IEmployeeRepository context): IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _context = context;
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _context.DeleteEmployeeAsync(request.id);
        }
    }
}
