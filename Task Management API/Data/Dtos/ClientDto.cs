namespace Task_Management_API.Data.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public string ContactPerson { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public int ProjectCount { get; set; }
    }
}
