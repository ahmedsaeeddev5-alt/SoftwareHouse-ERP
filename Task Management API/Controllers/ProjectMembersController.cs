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
    public class ProjectMembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectMembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("project/{projectId:int}")]
        public async Task<
            ActionResult<List<ProjectMemberDto>>>
            GetProjectMembers(int projectId)
        {
            var result =
                await _mediator.Send(
                    new GetProjectMembersQuery(projectId));

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectMemberDto>>
            GetProjectMember(int id)
        {
            var result =
                await _mediator.Send(
                    new GetProjectMemberByIdQuery(id));

            if (result == null)
                return NotFound(new
                {
                    message = "Project member not found"
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectMemberDto>>
            CreateProjectMember(
                CreateProjectMemberDto dto)
        {
            var result =
                await _mediator.Send(
                    new CreateProjectMemberCommand(dto));

            return CreatedAtAction(
                nameof(GetProjectMember),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProjectMemberDto>>
            UpdateProjectMember(
                int id,
                UpdateProjectMemberDto dto)
        {
            var result =
                await _mediator.Send(
                    new UpdateProjectMemberCommand(id, dto));

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult>
            DeleteProjectMember(int id)
        {
            await _mediator.Send(
                new DeleteProjectMemberCommand(id));

            return NoContent();
        }
    }
}