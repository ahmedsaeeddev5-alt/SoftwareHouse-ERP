using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repositories;

namespace Task_Management_API.Features.Payments.Queries.GetPaymentById;

public class GetPaymentByIdHandler
    : IRequestHandler<GetPaymentByIdQuery, PaymentReadDto?>
{
    private readonly IPaymentRepository _repository;

    public GetPaymentByIdHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaymentReadDto?> Handle(
        GetPaymentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var payment = await _repository.GetByIdAsync(request.Id);

        if (payment == null)
            return null;

        return new PaymentReadDto
        {
            Id = payment.Id,
            PaymentNumber = payment.PaymentNumber,

            InvoiceId = payment.InvoiceId,
            InvoiceNumber = payment.Invoice.InvoiceNumber,

            PaymentDate = payment.PaymentDate,
            Amount = payment.Amount,
            PaymentMethod = payment.PaymentMethod,
            Currency = payment.Currency,
            Status = payment.Status,
            Reference = payment.Reference,
            Notes = payment.Notes,
            CreatedDate = payment.CreatedDate
        };
    }
}