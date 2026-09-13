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
    public class MilestonesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MilestonesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Milestones/project/1
        [HttpGet("project/{projectId:int}")]
        public async Task<ActionResult<List<MilestoneDto>>>
            GetProjectMilestones(int projectId)
        {
            var result =
                await _mediator.Send(
                    new GetMilestonesQuery(projectId));

            return Ok(result);
        }

        // GET: api/Milestones/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MilestoneDto>>
            GetMilestone(int id)
        {
            var result =
                await _mediator.Send(
                    new GetMilestoneByIdQuery(id));

            if (result == null)
                return NotFound(new
                {
                    message = "Milestone not found"
                });

            return Ok(result);
        }

        // POST: api/Milestones
        [HttpPost]
        public async Task<ActionResult<MilestoneDto>>
            CreateMilestone(CreateMilestoneDto dto)
        {
            var result =
                await _mediator.Send(
                    new CreateMilestoneCommand(dto));

            return CreatedAtAction(
                nameof(GetMilestone),
                new { id = result.Id },
                result);
        }

        // PUT: api/Milestones/1
        [HttpPut("{id:int}")]
        public async Task<ActionResult<MilestoneDto>>
            UpdateMilestone(
                int id,
                UpdateMilestoneDto dto)
        {
            var result =
                await _mediator.Send(
                    new UpdateMilestoneCommand(id, dto));

            return Ok(result);
        }

        // DELETE: api/Milestones/1
        [HttpDelete("{id:int}")]
        public async Task<IActionResult>
            DeleteMilestone(int id)
        {
            await _mediator.Send(
                new DeleteMilestoneCommand(id));

            return NoContent();
        }
    }
}

