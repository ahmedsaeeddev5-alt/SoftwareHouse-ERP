using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // =========================
        // Get All Tasks
        // =========================

        [HttpGet]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetAll()
        {
            var result = await _mediator.Send(
                new GetAllItemsQuery());

            return Ok(result);
        }

        // =========================
        // Get Task By Id
        // =========================

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemReadDto>> GetById(int id)
        {
            var result = await _mediator.Send(
                new GetItemByIdQuery(id));

            if (result == null)
                return NotFound(new
                {
                    message = "Task not found"
                });

            return Ok(result);
        }

        // =========================
        // Create Task
        // =========================

        [HttpPost]
        public async Task<ActionResult<TaskItemReadDto>> Create(
            [FromForm] TaskItemCreateDto dto)
        {
            var userId = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var result = await _mediator.Send(
                new InsertItemCommand(dto, userId));

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        // =========================
        // Update Task
        // =========================

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskItemReadDto>> Update(
            int id,
            [FromForm] TaskItemCreateDto dto)
        {
            var result = await _mediator.Send(
                new UpdateItemCommand(id, dto));

            return Ok(result);
        }

        // =========================
        // Delete Task
        // =========================

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(
                new DeleteItemCommand(id));

            return Ok(new
            {
                message = "Task deleted successfully"
            });
        }
    }
}