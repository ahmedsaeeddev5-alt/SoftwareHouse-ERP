namespace Task_Management_API.Data.Dtos
{
    public class MilestoneDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;
    }
}
