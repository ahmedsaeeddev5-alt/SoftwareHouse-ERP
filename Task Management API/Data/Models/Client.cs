namespace Task_Management_API.Data.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public string? ContactPerson { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
            = new List<Project>();
    }
}
