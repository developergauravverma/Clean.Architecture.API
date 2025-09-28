using Clean.Application.Commands;
using Clean.Application.Queries;
using Clean.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            var result = await sender.Send(new AddEmployeeCommand(employee));
            return Ok(result);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var result = await sender.Send(new GetAllEmployeeQuery());
            return Ok(result);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] Guid id)
        {
            var result = await sender.Send(new GetEmployeeById(id));
            return Ok(result);
        }
        [HttpPut("")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            var result = await sender.Send(new UpdateEmployeeCommand(employee));
            return Ok(result);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var result = await sender.Send(new DeleteEmployeeCommand(id));
            return Ok(result);
        }
    }
}
