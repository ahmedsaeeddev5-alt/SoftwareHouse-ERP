namespace Task_Management_API.Data.Dtos
{
    public class ExpenseReadDto
    {
        public int Id { get; set; }

        public string ExpenseNumber { get; set; } = string.Empty;

        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;

        public DateTime ExpenseDate { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}
