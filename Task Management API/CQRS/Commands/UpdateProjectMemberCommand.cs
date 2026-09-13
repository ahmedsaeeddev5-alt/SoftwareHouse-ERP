using MediatR;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.CQRS.Commands
{
    public record UpdateProjectMemberCommand(
       int Id,
       UpdateProjectMemberDto Member)
       : IRequest<ProjectMemberDto>;
}
