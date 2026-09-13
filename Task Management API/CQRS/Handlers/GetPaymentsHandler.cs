using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repositories;

namespace Task_Management_API.Features.Payments.Queries.GetPayments;

public class GetPaymentsHandler
    : IRequestHandler<GetPaymentsQuery, IEnumerable<PaymentReadDto>>
{
    private readonly IPaymentRepository _repository;

    public GetPaymentsHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PaymentReadDto>> Handle(
        GetPaymentsQuery request,
        CancellationToken cancellationToken)
    {
        var payments = await _repository.GetAllAsync();

        return payments.Select(payment => new PaymentReadDto
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
        });
    }
}