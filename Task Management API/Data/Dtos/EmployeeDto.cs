namespace Task_Management_API.Data.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string EmployeeNumber { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; } = string.Empty;

        public string? UserId { get; set; }

        public string? UserName { get; set; }
    }
}
