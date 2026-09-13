namespace Task_Management_API.Data.Dtos
{
    public class ProjectTaskDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Status { get; set; } = string.Empty;

        public string Priority { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime? DueDate { get; set; }

        public int? EmployeeId { get; set; }

        public string? EmployeeName { get; set; }
    }
}
