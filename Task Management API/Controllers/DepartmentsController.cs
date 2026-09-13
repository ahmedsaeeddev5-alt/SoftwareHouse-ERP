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
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentDto>>>
            GetDepartments()
        {
            var result =
                await _mediator.Send(new GetDepartmentsQuery());

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DepartmentDto>>
            GetDepartment(int id)
        {
            var result =
                await _mediator.Send(
                    new GetDepartmentByIdQuery(id));

            if (result == null)
                return NotFound(new
                {
                    message = "Department not found"
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentDto>>
            CreateDepartment(CreateDepartmentDto dto)
        {
            var result =
                await _mediator.Send(
                    new CreateDepartmentCommand(dto));

            return CreatedAtAction(
                nameof(GetDepartment),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DepartmentDto>>
            UpdateDepartment(
                int id,
                UpdateDepartmentDto dto)
        {
            var result =
                await _mediator.Send(
                    new UpdateDepartmentCommand(id, dto));

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult>
            DeleteDepartment(int id)
        {
            await _mediator.Send(
                new DeleteDepartmentCommand(id));

            return NoContent();
        }
    }
}