using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record DeleteAttendanceCommand(
    int Id
) : IRequest<bool>;
}
