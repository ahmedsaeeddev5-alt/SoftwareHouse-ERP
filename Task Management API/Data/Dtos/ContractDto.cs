namespace Task_Management_API.Data.Dtos
{
    public class ContractDto
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; } = string.Empty;

        public int ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;

        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public decimal TotalAmount { get; set; }
        public string Currency { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
