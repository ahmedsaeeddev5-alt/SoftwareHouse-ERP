namespace Task_Management_API.Data.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public decimal Budget { get; set; }

        public int ClientId { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public int MemberCount { get; set; }

        public int TaskCount { get; set; }
    }
}
