namespace Task_Management_API.Data.Dtos
{
    public class PaymentCreateDto
    {
        public string PaymentNumber { get; set; } = string.Empty;

        public int InvoiceId { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = "BankTransfer";

        public string Currency { get; set; } = "USD";

        public string Status { get; set; } = "Completed";

        public string? Reference { get; set; }

        public string? Notes { get; set; }
    }
}
