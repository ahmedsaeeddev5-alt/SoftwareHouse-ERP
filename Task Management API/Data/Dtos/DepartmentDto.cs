namespace Task_Management_API.Data.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int EmployeeCount { get; set; }

        public List<DepartmentEmployeeDto> Employees { get; set; }
            = new List<DepartmentEmployeeDto>();
    }

    public class DepartmentEmployeeDto
    {
        public int Id { get; set; }

        public string EmployeeNumber { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string? Phone { get; set; }
    }
}