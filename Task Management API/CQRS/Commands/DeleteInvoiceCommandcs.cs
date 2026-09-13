using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record DeleteInvoiceCommand(
    int Id
) : IRequest<bool>;
}
