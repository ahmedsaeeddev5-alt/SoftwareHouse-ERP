using MediatR;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.CQRS.Commands
{
    public record UpdateClientCommand(int Id, UpdateClientDto Client)
        : IRequest<ClientDto>;
}
