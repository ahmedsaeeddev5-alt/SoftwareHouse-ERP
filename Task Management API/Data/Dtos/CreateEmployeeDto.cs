namespace Task_Management_API.Data.Dtos
{
    public class CreateEmployeeDto
    {
        public string EmployeeNumber { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public string? UserId { get; set; }
    }
}
