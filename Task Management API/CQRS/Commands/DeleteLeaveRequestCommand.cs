using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record DeleteLeaveRequestCommand(
    int Id
) : IRequest<bool>;
}
