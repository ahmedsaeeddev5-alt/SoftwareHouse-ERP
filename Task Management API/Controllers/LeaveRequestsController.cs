using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;


namespace Task_Management_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaveRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/LeaveRequests
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeaveRequestReadDto>>>
        GetLeaveRequests()
    {
        var leaveRequests = await _mediator.Send(
            new GetLeaveRequestsQuery());

        return Ok(leaveRequests);
    }

    // GET: api/LeaveRequests/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestReadDto>>
        GetLeaveRequestById(int id)
    {
        var leaveRequest = await _mediator.Send(
            new GetLeaveRequestByIdQuery(id));

        if (leaveRequest == null)
        {
            return NotFound(new
            {
                message = "Leave request not found."
            });
        }

        return Ok(leaveRequest);
    }

    // POST: api/LeaveRequests
    [HttpPost]
    public async Task<ActionResult<LeaveRequestReadDto>>
        CreateLeaveRequest(
            [FromBody] LeaveRequestCreateDto dto)
    {
        var leaveRequest = await _mediator.Send(
            new CreateLeaveRequestCommand(dto));

        return CreatedAtAction(
            nameof(GetLeaveRequestById),
            new { id = leaveRequest.Id },
            leaveRequest);
    }

    // PUT: api/LeaveRequests/5
    [HttpPut("{id}")]
    public async Task<ActionResult<LeaveRequestReadDto>>
        UpdateLeaveRequest(
            int id,
            [FromBody] LeaveRequestCreateDto dto)
    {
        var leaveRequest = await _mediator.Send(
            new UpdateLeaveRequestCommand(id, dto));

        if (leaveRequest == null)
        {
            return NotFound(new
            {
                message = "Leave request not found."
            });
        }

        return Ok(leaveRequest);
    }

    // DELETE: api/LeaveRequests/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLeaveRequest(int id)
    {
        var result = await _mediator.Send(
            new DeleteLeaveRequestCommand(id));

        if (!result)
        {
            return NotFound(new
            {
                message = "Leave request not found."
            });
        }

        return NoContent();
    }
}