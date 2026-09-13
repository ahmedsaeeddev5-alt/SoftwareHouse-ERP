namespace Task_Management_API.Data.Models
{
    public class ProjectMember
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; } = null!;

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;

        public string Role { get; set; } = string.Empty;

        public DateTime AssignedDate { get; set; }
    }
}
