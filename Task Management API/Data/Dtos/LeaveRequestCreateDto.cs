namespace Task_Management_API.Data.Dtos
{
    public class LeaveRequestCreateDto
    {
        public int EmployeeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LeaveType { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public string? Reason { get; set; }

        public string? Notes { get; set; }
    }
}
