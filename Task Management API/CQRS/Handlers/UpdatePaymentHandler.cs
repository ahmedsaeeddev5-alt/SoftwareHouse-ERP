using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repositories;

namespace Task_Management_API.Features.Payments.Commands.UpdatePayment;

public class UpdatePaymentHandler
    : IRequestHandler<UpdatePaymentCommand, PaymentReadDto?>
{
    private readonly IPaymentRepository _repository;

    public UpdatePaymentHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaymentReadDto?> Handle(
        UpdatePaymentCommand request,
        CancellationToken cancellationToken)
    {
        var payment = await _repository.GetByIdAsync(request.Id);

        if (payment == null)
            return null;

        var dto = request.Payment;

        payment.PaymentNumber = dto.PaymentNumber;
        payment.InvoiceId = dto.InvoiceId;
        payment.PaymentDate = dto.PaymentDate;
        payment.Amount = dto.Amount;
        payment.PaymentMethod = dto.PaymentMethod;
        payment.Currency = dto.Currency;
        payment.Status = dto.Status;
        payment.Reference = dto.Reference;
        payment.Notes = dto.Notes;

        await _repository.UpdateAsync(payment);

        var result = await _repository.GetByIdAsync(payment.Id);

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