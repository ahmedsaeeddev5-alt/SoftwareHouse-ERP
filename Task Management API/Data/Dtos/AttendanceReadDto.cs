namespace Task_Management_API.Data.Dtos
{
    public class AttendanceReadDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public DateTime AttendanceDate { get; set; }

        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public string Status { get; set; } = string.Empty;

        public string? Notes { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
