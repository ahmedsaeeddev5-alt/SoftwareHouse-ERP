namespace Task_Management_API.Data.Models
{
    public class Milestone
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public string Status { get; set; } = "Todo";

        // Project
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; } = null!;
    }
}
