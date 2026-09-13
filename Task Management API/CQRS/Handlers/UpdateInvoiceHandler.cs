using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repositories;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Invoices.Commands.UpdateInvoice;

public class UpdateInvoiceHandler
    : IRequestHandler<UpdateInvoiceCommand, InvoiceReadDto?>
{
    private readonly IInvoiceRepository _repository;

    public UpdateInvoiceHandler(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<InvoiceReadDto?> Handle(
        UpdateInvoiceCommand request,
        CancellationToken cancellationToken)
    {
        var invoice = await _repository.GetByIdAsync(request.Id);

        if (invoice == null)
            return null;

        var dto = request.Invoice;

        invoice.InvoiceNumber = dto.InvoiceNumber;
        invoice.ContractId = dto.ContractId;
        invoice.InvoiceDate = dto.InvoiceDate;
        invoice.DueDate = dto.DueDate;
        invoice.Amount = dto.Amount;
        invoice.TaxAmount = dto.TaxAmount;
        invoice.TotalAmount = dto.TotalAmount;
        invoice.Currency = dto.Currency;
        invoice.Status = dto.Status;
        invoice.Notes = dto.Notes;

        await _repository.UpdateAsync(invoice);

        var result = await _repository.GetByIdAsync(invoice.Id);

        return new InvoiceReadDto
        {
            Id = result!.Id,
            InvoiceNumber = result.InvoiceNumber,

            ContractId = result.ContractId,
            ContractNumber = result.Contract.ContractNumber,

            InvoiceDate = result.InvoiceDate,
            DueDate = result.DueDate,
            Amount = result.Amount,
            TaxAmount = result.TaxAmount,
            TotalAmount = result.TotalAmount,
            Currency = result.Currency,
            Status = result.Status,
            Notes = result.Notes,
            CreatedDate = result.CreatedDate
        };
    }
}