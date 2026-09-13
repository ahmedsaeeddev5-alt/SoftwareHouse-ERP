namespace Task_Management_API.Data.Dtos
{
    public class CreateProjectMemberDto
    {
        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }

        public string Role { get; set; } = string.Empty;

        public DateTime AssignedDate { get; set; }
    }
}
