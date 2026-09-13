using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Data.Models;
using Task_Management_API.Repositories;

namespace Task_Management_API.Features.Payments.Commands.CreatePayment;

public class CreatePaymentHandler
    : IRequestHandler<CreatePaymentCommand, PaymentReadDto>
{
    private readonly IPaymentRepository _repository;

    public CreatePaymentHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaymentReadDto> Handle(
        CreatePaymentCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.Payment;

        var payment = new Payment
        {
            PaymentNumber = dto.PaymentNumber,
            InvoiceId = dto.InvoiceId,
            PaymentDate = dto.PaymentDate,
            Amount = dto.Amount,
            PaymentMethod = dto.PaymentMethod,
            Currency = dto.Currency,
            Status = dto.Status,
            Reference = dto.Reference,
            Notes = dto.Notes
        };

        var createdPayment = await _repository.AddAsync(payment);

        var result = await _repository.GetByIdAsync(createdPayment.Id);

        return new PaymentReadDto
        {
            Id = result!.Id,
            PaymentNumber = result.PaymentNumber,

            InvoiceId = result.InvoiceId,
            InvoiceNumber = result.Invoice.InvoiceNumber,

            PaymentDate = result.PaymentDate,
            Amount = result.Amount,
            PaymentMethod = result.PaymentMethod,
            Currency = result.Currency,
            Status = result.Status,
            Reference = result.Reference,
            Notes = result.Notes,
            CreatedDate = result.CreatedDate
        };
    }
}