namespace Task_Management_API.Data.Dtos
{
    public class CreateMilestoneDto
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public string Status { get; set; } = "Todo";

        public int ProjectId { get; set; }
    }
}
