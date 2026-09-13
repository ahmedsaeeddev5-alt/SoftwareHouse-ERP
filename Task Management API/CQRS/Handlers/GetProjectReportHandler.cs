using MediatR;
using Microsoft.EntityFrameworkCore;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.Features.Reports.ProjectReports.Queries.GetProjectReport;

public class GetProjectReportHandler
    : IRequestHandler<GetProjectReportQuery, ProjectReportDto>
{
    private readonly AppDbContext _context;

    public GetProjectReportHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProjectReportDto> Handle(
     GetProjectReportQuery request,
     CancellationToken cancellationToken)
    {
        var projects = _context.Projects.AsNoTracking();

        return new ProjectReportDto
        {
            TotalProjects = await projects.CountAsync(
                cancellationToken),

            TotalTasks = await _context.Tasks.CountAsync(
                cancellationToken),

            PlanningProjects = await projects.CountAsync(
                p => p.Status == "Planning",
                cancellationToken),

            InProgressProjects = await projects.CountAsync(
                p => p.Status == "In Progress",
                cancellationToken),

            CompletedProjects = await projects.CountAsync(
                p => p.Status == "Completed",
                cancellationToken),

            CancelledProjects = await projects.CountAsync(
                p => p.Status == "Cancelled",
                cancellationToken),

            TotalProjectValue = await projects.SumAsync(
                p => p.Budget,
                cancellationToken)
        };
    }
}