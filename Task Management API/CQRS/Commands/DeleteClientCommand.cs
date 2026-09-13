using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record DeleteClientCommand(int Id)
        : IRequest<bool>;
}
