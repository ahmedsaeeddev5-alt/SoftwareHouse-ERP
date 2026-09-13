using MediatR;
using Microsoft.EntityFrameworkCore;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetDashboardHandler : IRequestHandler<GetDashboardQuery, DashboardDto>
    {
        private readonly AppDbContext _context;

        public GetDashboardHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<DashboardDto> Handle(
     GetDashboardQuery request,
     CancellationToken cancellationToken)
        {
            var totalContracts = await _context.Contracts
                .AsNoTracking()
                .SumAsync(
                    c => c.TotalAmount,
                    cancellationToken);

            var totalInvoiced = await _context.Invoices
                .AsNoTracking()
                .SumAsync(
                    i => i.TotalAmount,
                    cancellationToken);

            var totalPaid = await _context.Payments
                .AsNoTracking()
                .SumAsync(
                    p => p.Amount,
                    cancellationToken);

            var totalExpenses = await _context.Expenses
                .AsNoTracking()
                .SumAsync(
                    e => e.Amount,
                    cancellationToken);

            var pendingLeaveRequests = await _context.LeaveRequests
                .AsNoTracking()
                .CountAsync(
                    l => l.Status == "Pending",
                    cancellationToken);

            var dashboard = new DashboardDto
            {
                EmployeesCount = await _context.Employees
                    .CountAsync(cancellationToken),

                DepartmentsCount = await _context.Departments
                    .CountAsync(cancellationToken),

                ClientsCount = await _context.Clients
                    .CountAsync(cancellationToken),

                ProjectsCount = await _context.Projects
                    .CountAsync(cancellationToken),

                TasksCount = await _context.Tasks
                    .CountAsync(cancellationToken),

                CompletedTasks = await _context.Tasks
                    .CountAsync(
                        t => t.Status == "Completed",
                        cancellationToken),

                PendingTasks = await _context.Tasks
                    .CountAsync(
                        t => t.Status != "Completed",
                        cancellationToken),

                ActiveProjects = await _context.Projects
                    .CountAsync(
                        p => p.Status == "Active",
                        cancellationToken),

                CompletedProjects = await _context.Projects
                    .CountAsync(
                        p => p.Status == "Completed",
                        cancellationToken),

                // Financial
                TotalContracts = totalContracts,

                TotalInvoiced = totalInvoiced,

                TotalPaid = totalPaid,

                TotalExpenses = totalExpenses,

                OutstandingAmount = totalInvoiced - totalPaid,

                NetProfit = totalPaid - totalExpenses,

                // HR
                PendingLeaveRequests = pendingLeaveRequests,

                RecentProjects = await _context.Projects
                    .Include(p => p.Client)
                    .OrderByDescending(p => p.Id)
                    .Take(5)
                    .Select(p => new RecentProjectDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        ClientName = p.Client.CompanyName,
                        Status = p.Status,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate
                    })
                    .ToListAsync(cancellationToken)
            };

            return dashboard;
        }
    }
}
