using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record DeleteExpenseCommand(
    int Id
) : IRequest<bool>;
}
