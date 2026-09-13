namespace Task_Management_API.Data.Dtos
{
    public class ProjectReportDto
    {
        public int TotalProjects { get; set; }

        public int PlanningProjects { get; set; }

        public int InProgressProjects { get; set; }

        public int CompletedProjects { get; set; }

        public int CancelledProjects { get; set; }

        public decimal TotalProjectValue { get; set; }
        public int TotalTasks { get; set; }
    }
}
