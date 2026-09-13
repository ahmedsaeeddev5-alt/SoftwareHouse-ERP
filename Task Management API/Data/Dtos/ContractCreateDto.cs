namespace Task_Management_API.Data.Dtos
{
    public class ContractCreateDto
    {
        public string ContractNumber { get; set; } = string.Empty;

        public int ClientId { get; set; }
        public int ProjectId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Currency { get; set; } = "USD";

        public string Status { get; set; } = "Active";

        public string? Description { get; set; }
    }
}
