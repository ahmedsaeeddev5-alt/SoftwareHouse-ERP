namespace Task_Management_API.Data.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;

        public DateTime AttendanceDate { get; set; }

        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public string Status { get; set; } = "Present";

        public string? Notes { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
