namespace Task_Management_API.Data.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public string ContractNumber { get; set; } = string.Empty;

        public int ClientId { get; set; }
        public virtual Client Client { get; set; } = null!;

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Currency { get; set; } = "USD";

        public string Status { get; set; } = "Active";

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
