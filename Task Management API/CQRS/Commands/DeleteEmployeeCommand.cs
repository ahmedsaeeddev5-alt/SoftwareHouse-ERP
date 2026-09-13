using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record DeleteEmployeeCommand(int Id)
        : IRequest<bool>;
}
