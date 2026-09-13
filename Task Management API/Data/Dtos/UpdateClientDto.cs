namespace Task_Management_API.Data.Dtos
{
    public class UpdateClientDto
    {
        public string CompanyName { get; set; } = string.Empty;

        public string ContactPerson { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }
    }
}
