using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task_Management_API.CQRS.Queries;

namespace Task_Management_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboard(
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetDashboardQuery(),
                cancellationToken);

            return Ok(result);
        }
    }
}