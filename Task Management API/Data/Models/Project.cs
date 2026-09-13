namespace Task_Management_API.Data.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Status { get; set; } = "Planning";

        public decimal Budget { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;

        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
            = new List<ProjectMember>();

        public virtual ICollection<TaskItem> Tasks { get; set; }
            = new List<TaskItem>();
    }
}
