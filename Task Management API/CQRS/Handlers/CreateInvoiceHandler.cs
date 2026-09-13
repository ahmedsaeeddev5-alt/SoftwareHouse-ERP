using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Data.Models;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Invoices.Commands.CreateInvoice;

public class CreateInvoiceHandler
    : IRequestHandler<CreateInvoiceCommand, InvoiceReadDto>
{
    private readonly IInvoiceRepository _repository;

    public CreateInvoiceHandler(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<InvoiceReadDto> Handle(
        CreateInvoiceCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.Invoice;

        var invoice = new Invoice
        {
            InvoiceNumber = dto.InvoiceNumber,
            ContractId = dto.ContractId,
            InvoiceDate = dto.InvoiceDate,
            DueDate = dto.DueDate,
            Amount = dto.Amount,
            TaxAmount = dto.TaxAmount,
            TotalAmount = dto.TotalAmount,
            Currency = dto.Currency,
            Status = dto.Status,
            Notes = dto.Notes
        };

        var createdInvoice = await _repository.AddAsync(invoice);

        var result = await _repository.GetByIdAsync(createdInvoice.Id);

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