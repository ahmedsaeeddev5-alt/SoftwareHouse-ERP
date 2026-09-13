namespace Task_Management_API.Data.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LeaveType { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public string? Reason { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
