using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendancesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AttendancesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Attendances
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AttendanceReadDto>>> GetAttendances()
    {
        var attendances = await _mediator.Send(
            new GetAttendancesQuery());

        return Ok(attendances);
    }

    // GET: api/Attendances/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AttendanceReadDto>> GetAttendanceById(int id)
    {
        var attendance = await _mediator.Send(
            new GetAttendanceByIdQuery(id));

        if (attendance == null)
        {
            return NotFound(new
            {
                message = "Attendance record not found."
            });
        }

        return Ok(attendance);
    }

    // POST: api/Attendances
    [HttpPost]
    public async Task<ActionResult<AttendanceReadDto>> CreateAttendance(
        [FromBody] AttendanceCreateDto dto)
    {
        var attendance = await _mediator.Send(
            new CreateAttendanceCommand(dto));

        return CreatedAtAction(
            nameof(GetAttendanceById),
            new { id = attendance.Id },
            attendance);
    }

    // PUT: api/Attendances/5
    [HttpPut("{id}")]
    public async Task<ActionResult<AttendanceReadDto>> UpdateAttendance(
        int id,
        [FromBody] AttendanceCreateDto dto)
    {
        var attendance = await _mediator.Send(
            new UpdateAttendanceCommand(id, dto));

        if (attendance == null)
        {
            return NotFound(new
            {
                message = "Attendance record not found."
            });
        }

        return Ok(attendance);
    }

    // DELETE: api/Attendances/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAttendance(int id)
    {
        var result = await _mediator.Send(
            new DeleteAttendanceCommand(id));

        if (!result)
        {
            return NotFound(new
            {
                message = "Attendance record not found."
            });
        }

        return NoContent();
    }
}