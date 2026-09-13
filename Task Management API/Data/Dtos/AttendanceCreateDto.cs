namespace Task_Management_API.Data.Dtos
{
    public class AttendanceCreateDto
    {
        public int EmployeeId { get; set; }

        public DateTime AttendanceDate { get; set; }

        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public string Status { get; set; } = "Present";

        public string? Notes { get; set; }
    }
}
