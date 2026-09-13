namespace Task_Management_API.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string EmployeeNumber { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        // Department
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } = null!;

        // Identity User
        public string? UserId { get; set; }

        public virtual AppUser? User { get; set; }
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
    = new List<ProjectMember>();
    }
}
