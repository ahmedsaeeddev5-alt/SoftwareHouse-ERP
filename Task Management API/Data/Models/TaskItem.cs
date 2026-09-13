using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Management_API.Data.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Status { get; set; } = "Todo";

        public string Priority { get; set; } = "Medium";

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? DueDate { get; set; }

        // Project
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; } = null!;

        // Assigned Employee
        public int? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }

        // Old Identity User - temporarily kept
        public string? UserId { get; set; }

        public virtual AppUser? User { get; set; }
        public byte[]? Image { get; set; }
    }
}