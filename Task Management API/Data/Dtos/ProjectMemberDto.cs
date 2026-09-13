namespace Task_Management_API.Data.Dtos
{
    public class ProjectMemberDto
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public DateTime AssignedDate { get; set; }
    }
}
