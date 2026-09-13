namespace Task_Management_API.Data.Dtos
{
    public class InvoiceReadDto
    {
        public int Id { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;

        public int ContractId { get; set; }
        public string ContractNumber { get; set; } = string.Empty;

        public DateTime InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }

        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }

        public string Currency { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string? Notes { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
