using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record DeleteProjectMemberCommand(int Id)
         : IRequest<bool>;
}
