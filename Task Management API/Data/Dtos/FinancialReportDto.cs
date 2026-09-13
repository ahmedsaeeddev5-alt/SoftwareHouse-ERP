namespace Task_Management_API.Data.Dtos
{
    public class FinancialReportDto
    {
        public decimal TotalContracts { get; set; }

        public decimal TotalInvoiced { get; set; }

        public decimal TotalPaid { get; set; }

        public decimal TotalExpenses { get; set; }

        public decimal OutstandingAmount { get; set; }

        public decimal NetProfit { get; set; }
    }
}
