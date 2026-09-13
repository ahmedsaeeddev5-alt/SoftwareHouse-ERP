using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record DeleteContractCommand(
    int Id
) : IRequest<bool>;
}
