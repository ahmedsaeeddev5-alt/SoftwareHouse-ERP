namespace Task_Management_API.Data.Dtos
{
    public class InvoiceCreateDto
    {
        public string InvoiceNumber { get; set; } = string.Empty;

        public int ContractId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime? DueDate { get; set; }

        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }

        public string Currency { get; set; } = "USD";

        public string Status { get; set; } = "Pending";

        public string? Notes { get; set; }
    }
}
