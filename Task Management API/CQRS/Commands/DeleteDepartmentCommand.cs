using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record DeleteDepartmentCommand(int Id)
       : IRequest<bool>;
}
