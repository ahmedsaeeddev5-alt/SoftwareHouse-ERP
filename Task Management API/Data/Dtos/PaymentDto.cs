namespace Task_Management_API.Data.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }

        public string PaymentNumber { get; set; } = string.Empty;

        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        public string Currency { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string? Reference { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
