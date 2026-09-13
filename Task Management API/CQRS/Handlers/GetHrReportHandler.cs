using MediatR;
using Microsoft.EntityFrameworkCore;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.Features.Reports.HrReports.Queries.GetHrReport;

public class GetHrReportHandler
    : IRequestHandler<GetHrReportQuery, HrReportDto>
{
    private readonly AppDbContext _context;

    public GetHrReportHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<HrReportDto> Handle(
        GetHrReportQuery request,
        CancellationToken cancellationToken)
    {
        var totalEmployees = await _context.Employees
            .AsNoTracking()
            .CountAsync(cancellationToken);

        var totalAttendanceRecords = await _context.Attendances
            .AsNoTracking()
            .CountAsync(cancellationToken);

        var presentDays = await _context.Attendances
            .AsNoTracking()
            .CountAsync(
                a => a.Status == "Present",
                cancellationToken);

        var absentDays = await _context.Attendances
            .AsNoTracking()
            .CountAsync(
                a => a.Status == "Absent",
                cancellationToken);

        var totalLeaveRequests = await _context.LeaveRequests
            .AsNoTracking()
            .CountAsync(cancellationToken);

        var pendingLeaveRequests = await _context.LeaveRequests
            .AsNoTracking()
            .CountAsync(
                l => l.Status == "Pending",
                cancellationToken);

        var approvedLeaveRequests = await _context.LeaveRequests
            .AsNoTracking()
            .CountAsync(
                l => l.Status == "Approved",
                cancellationToken);

        var rejectedLeaveRequests = await _context.LeaveRequests
            .AsNoTracking()
            .CountAsync(
                l => l.Status == "Rejected",
                cancellationToken);

        var leaveDays = await _context.LeaveRequests
            .AsNoTracking()
            .Where(l => l.Status == "Approved")
            .Select(l =>
                EF.Functions.DateDiffDay(
                    l.StartDate,
                    l.EndDate) + 1)
            .SumAsync(cancellationToken);

        return new HrReportDto
        {
            TotalEmployees = totalEmployees,

            TotalAttendanceRecords = totalAttendanceRecords,

            PresentDays = presentDays,

            AbsentDays = absentDays,

            LeaveDays = leaveDays,

            TotalLeaveRequests = totalLeaveRequests,

            PendingLeaveRequests = pendingLeaveRequests,

            ApprovedLeaveRequests = approvedLeaveRequests,

            RejectedLeaveRequests = rejectedLeaveRequests
        };
    }
}