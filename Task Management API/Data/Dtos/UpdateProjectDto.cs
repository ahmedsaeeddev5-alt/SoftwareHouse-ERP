namespace Task_Management_API.Data.Dtos
{
    public class UpdateProjectDto
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Status { get; set; } = "Planning";

        public decimal Budget { get; set; }

        public int ClientId { get; set; }
    }
}
