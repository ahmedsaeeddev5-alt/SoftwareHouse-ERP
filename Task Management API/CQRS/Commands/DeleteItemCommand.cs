using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record DeleteItemCommand(int Id)
    : IRequest<bool>;
}
