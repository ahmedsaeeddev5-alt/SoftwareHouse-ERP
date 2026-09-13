namespace Task_Management_API.Data.Dtos
{
    public class DashboardDto
    {
        public int EmployeesCount { get; set; }
        public int DepartmentsCount { get; set; }
        public int ClientsCount { get; set; }
        public int ProjectsCount { get; set; }
        public int TasksCount { get; set; }

        public int CompletedTasks { get; set; }
        public int PendingTasks { get; set; }

        public int ActiveProjects { get; set; }
        public int CompletedProjects { get; set; }

        // Financial
        public decimal TotalContracts { get; set; }
        public decimal TotalInvoiced { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal OutstandingAmount { get; set; }
        public decimal NetProfit { get; set; }

        // HR
        public int PendingLeaveRequests { get; set; }

        public List<RecentProjectDto> RecentProjects { get; set; } = new();
    }

    public class RecentProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ClientName { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}