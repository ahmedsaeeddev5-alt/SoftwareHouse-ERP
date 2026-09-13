using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>>
            GetEmployees()
        {
            var result =
                await _mediator.Send(new GetEmployeesQuery());

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeDto>>
            GetEmployee(int id)
        {
            var result =
                await _mediator.Send(
                    new GetEmployeeByIdQuery(id));

            if (result == null)
                return NotFound(new
                {
                    message = "Employee not found"
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>>
            CreateEmployee(CreateEmployeeDto dto)
        {
            var result =
                await _mediator.Send(
                    new CreateEmployeeCommand(dto));

            return CreatedAtAction(
                nameof(GetEmployee),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmployeeDto>>
            UpdateEmployee(
                int id,
                UpdateEmployeeDto dto)
        {
            var result =
                await _mediator.Send(
                    new UpdateEmployeeCommand(id, dto));

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult>
            DeleteEmployee(int id)
        {
            await _mediator.Send(
                new DeleteEmployeeCommand(id));

            return NoContent();
        }

        [HttpPut("{id:int}/department")]
        public async Task<IActionResult> ReassignDepartment(
    int id,
    [FromBody] int departmentId)
        {
            var result = await _mediator.Send(
                new ReassignEmployeeDepartmentCommand(id, departmentId));

            if (!result)
                return BadRequest(new
                {
                    message = "Employee or department not found."
                });

            return NoContent();
        }
    }
}