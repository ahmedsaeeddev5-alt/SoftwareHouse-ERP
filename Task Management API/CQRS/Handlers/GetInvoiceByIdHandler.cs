using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repositories;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Invoices.Queries.GetInvoiceById;

public class GetInvoiceByIdHandler
    : IRequestHandler<GetInvoiceByIdQuery, InvoiceReadDto?>
{
    private readonly IInvoiceRepository _repository;

    public GetInvoiceByIdHandler(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<InvoiceReadDto?> Handle(
        GetInvoiceByIdQuery request,
        CancellationToken cancellationToken)
    {
        var invoice = await _repository.GetByIdAsync(request.Id);

        if (invoice == null)
            return null;

        return new InvoiceReadDto
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
        };
    }
}