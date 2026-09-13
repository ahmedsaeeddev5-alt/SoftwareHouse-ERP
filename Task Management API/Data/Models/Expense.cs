namespace Task_Management_API.Data.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public string ExpenseNumber { get; set; } = string.Empty;

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; } = null!;

        public DateTime ExpenseDate { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; } = "USD";

        public string Category { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
