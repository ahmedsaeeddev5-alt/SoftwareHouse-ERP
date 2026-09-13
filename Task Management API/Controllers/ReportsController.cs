using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Reports/projects
    [HttpGet("projects")]
    public async Task<ActionResult<ProjectReportDto>> GetProjectReport()
    {
        var report = await _mediator.Send(
            new GetProjectReportQuery());

        return Ok(report);
    }

    // GET: api/Reports/financial
    [HttpGet("financial")]
    public async Task<ActionResult<FinancialReportDto>> GetFinancialReport()
    {
        var report = await _mediator.Send(
            new GetFinancialReportQuery());

        return Ok(report);
    }

    // GET: api/Reports/hr
    [HttpGet("hr")]
    public async Task<ActionResult<HrReportDto>> GetHrReport()
    {
        var report = await _mediator.Send(
            new GetHrReportQuery());

        return Ok(report);
    }
}