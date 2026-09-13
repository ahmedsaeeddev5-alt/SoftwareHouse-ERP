using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record DeleteProjectCommand(int Id)
        : IRequest<bool>;
}
