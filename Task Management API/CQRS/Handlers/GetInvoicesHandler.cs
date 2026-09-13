using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repositories;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Invoices.Queries.GetInvoices;

public class GetInvoicesHandler
    : IRequestHandler<GetInvoicesQuery, IEnumerable<InvoiceReadDto>>
{
    private readonly IInvoiceRepository _repository;

    public GetInvoicesHandler(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<InvoiceReadDto>> Handle(
        GetInvoicesQuery request,
        CancellationToken cancellationToken)
    {
        var invoices = await _repository.GetAllAsync();

        return invoices.Select(invoice => new InvoiceReadDto
        {
            Id = invoice.Id,
            InvoiceNumber = invoice.InvoiceNumber,

            ContractId = invoice.ContractId,
            ContractNumber = invoice.Contract.ContractNumber,

            InvoiceDate = invoice.InvoiceDate,
            DueDate = invoice.DueDate,
            Amount = invoice.Amount,
            TaxAmount = invoice.TaxAmount,
            TotalAmount = invoice.TotalAmount,
            Currency = invoice.Currency,
            Status = invoice.Status,
            Notes = invoice.Notes,
            CreatedDate = invoice.CreatedDate
        });
    }
}