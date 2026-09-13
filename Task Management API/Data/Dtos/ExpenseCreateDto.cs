namespace Task_Management_API.Data.Dtos
{
    public class ExpenseCreateDto
    {
        public string ExpenseNumber { get; set; } = string.Empty;

        public int ProjectId { get; set; }

        public DateTime ExpenseDate { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; } = "USD";

        public string Category { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Status { get; set; } = "Pending";
    }
}
