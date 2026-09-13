using MediatR;
using Microsoft.EntityFrameworkCore;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.Features.Reports.FinancialReports.Queries.GetFinancialReport;

public class GetFinancialReportHandler
    : IRequestHandler<GetFinancialReportQuery, FinancialReportDto>
{
    private readonly AppDbContext _context;

    public GetFinancialReportHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<FinancialReportDto> Handle(
        GetFinancialReportQuery request,
        CancellationToken cancellationToken)
    {
        var totalContracts = await _context.Contracts
            .AsNoTracking()
            .SumAsync(
                c => c.TotalAmount,
                cancellationToken);

        var totalInvoiced = await _context.Invoices
            .AsNoTracking()
            .SumAsync(
                i => i.TotalAmount,
                cancellationToken);

        var totalPaid = await _context.Payments
            .AsNoTracking()
            .SumAsync(
                p => p.Amount,
                cancellationToken);

        var totalExpenses = await _context.Expenses
            .AsNoTracking()
            .SumAsync(
                e => e.Amount,
                cancellationToken);

        return new FinancialReportDto
        {
            TotalContracts = totalContracts,

            TotalInvoiced = totalInvoiced,

            TotalPaid = totalPaid,

            TotalExpenses = totalExpenses,

            OutstandingAmount = totalInvoiced - totalPaid,

            NetProfit = totalPaid - totalExpenses
        };
    }
}