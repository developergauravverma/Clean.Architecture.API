using Clean.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExternalVandorController(IMediator mediator) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAllPost()
        {
            var result = await mediator.Send(new GetAllPostQuery());
            return Ok(result);
        }
    }
}
