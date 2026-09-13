namespace Task_Management_API.Data.Dtos
{
    public class HrReportDto
    {
        public int TotalEmployees { get; set; }

        public int TotalAttendanceRecords { get; set; }

        public int PresentDays { get; set; }

        public int AbsentDays { get; set; }

        public int LeaveDays { get; set; }

        public int TotalLeaveRequests { get; set; }

        public int PendingLeaveRequests { get; set; }

        public int ApprovedLeaveRequests { get; set; }

        public int RejectedLeaveRequests { get; set; }
    }
}
