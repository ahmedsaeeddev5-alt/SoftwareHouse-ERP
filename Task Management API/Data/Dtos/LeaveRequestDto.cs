namespace Task_Management_API.Data.Dtos
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LeaveType { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string? Reason { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
