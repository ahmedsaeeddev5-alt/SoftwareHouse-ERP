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
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>>
            GetProjects()
        {
            var result =
                await _mediator.Send(new GetProjectsQuery());

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectDto>>
            GetProject(int id)
        {
            var result =
                await _mediator.Send(
                    new GetProjectByIdQuery(id));

            if (result == null)
                return NotFound(new
                {
                    message = "Project not found"
                });

            return Ok(result);
        }
        [HttpGet("{id:int}/details")]
        public async Task<ActionResult<ProjectDetailsDto>>
    GetProjectDetails(int id)
        {
            var result =
                await _mediator.Send(
                    new GetProjectDetailsQuery(id));

            if (result == null)
                return NotFound(new
                {
                    message = "Project not found"
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>>
            CreateProject(CreateProjectDto dto)
        {
            var result =
                await _mediator.Send(
                    new CreateProjectCommand(dto));

            return CreatedAtAction(
                nameof(GetProject),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProjectDto>>
            UpdateProject(
                int id,
                UpdateProjectDto dto)
        {
            var result =
                await _mediator.Send(
                    new UpdateProjectCommand(id, dto));

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult>
            DeleteProject(int id)
        {
            await _mediator.Send(
                new DeleteProjectCommand(id));

            return NoContent();
        }
    }
}