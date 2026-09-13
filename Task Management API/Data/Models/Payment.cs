namespace Task_Management_API.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public string PaymentNumber { get; set; } = string.Empty;

        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; } = null!;

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = "BankTransfer";

        public string Currency { get; set; } = "USD";

        public string Status { get; set; } = "Completed";

        public string? Reference { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
