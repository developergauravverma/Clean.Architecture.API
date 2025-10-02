using Clean.Core.Interfaces;
using Clean.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Queries
{
    public record GetAllPostQuery(): IRequest<Posts>;

    public class GetAllPostQueryHandler(IExternalVenderRepository repository) : IRequestHandler<GetAllPostQuery, Posts>
    {
        public async Task<Posts> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetExternalVenderData();
        }
    }
}
