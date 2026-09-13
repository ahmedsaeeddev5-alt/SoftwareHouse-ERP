namespace Task_Management_API.Data.Dtos
{
    public class TaskItemReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Status { get; set; } = string.Empty;

        public string Priority { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime? DueDate { get; set; }

        public int ProjectId { get; set; }

        public string? ProjectName { get; set; }

        public int? EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public string? ImageBase64 { get; set; }
    }
}
