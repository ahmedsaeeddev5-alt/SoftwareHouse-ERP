using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record DeletePaymentCommand(
    int Id
) : IRequest<bool>;
}
