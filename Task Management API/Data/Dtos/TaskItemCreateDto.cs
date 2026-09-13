namespace Task_Management_API.Data.Dtos
{
    public class TaskItemCreateDto
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Status { get; set; } = "Todo";

        public string Priority { get; set; } = "Medium";

        public DateTime? DueDate { get; set; }

        public int ProjectId { get; set; }

        public int? EmployeeId { get; set; }

        public IFormFile? Image { get; set; }
    }
}
