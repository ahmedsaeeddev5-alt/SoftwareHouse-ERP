using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Data.Models;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class CreateClientHandler
        : IRequestHandler<CreateClientCommand, ClientDto>
    {
        private readonly IClientRepository _repo;

        public CreateClientHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<ClientDto> Handle(
            CreateClientCommand request,
            CancellationToken cancellationToken)
        {
            var client = new Client
            {
                CompanyName = request.Client.CompanyName,
                ContactPerson = request.Client.ContactPerson,
                Email = request.Client.Email,
                Phone = request.Client.Phone,
                Address = request.Client.Address
            };

            var result = await _repo.InsertClientAsync(client);
            return new ClientDto
            {
                Id = result.Id,
                CompanyName = result.CompanyName,
                ContactPerson = result.ContactPerson,
                Email = result.Email,
                Phone = result.Phone,
                Address = result.Address,
                ProjectCount = 0
            };
        }
    }
}
