using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record DeleteMilestoneCommand(int Id)
        : IRequest<bool>;
}
