using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Repositories;

namespace Task_Management_API.Features.Payments.Commands.DeletePayment;

public class DeletePaymentHandler
    : IRequestHandler<DeletePaymentCommand, bool>
{
    private readonly IPaymentRepository _repository;

    public DeletePaymentHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeletePaymentCommand request,
        CancellationToken cancellationToken)
    {
        var payment = await _repository.GetByIdAsync(request.Id);

        if (payment == null)
            return false;

        await _repository.DeleteAsync(request.Id);

        return true;
    }
}