namespace Task_Management_API.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;

        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; } = null!;

        public DateTime InvoiceDate { get; set; }

        public DateTime? DueDate { get; set; }

        public decimal Amount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public string Currency { get; set; } = "USD";

        public string Status { get; set; } = "Pending";

        public string? Notes { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
