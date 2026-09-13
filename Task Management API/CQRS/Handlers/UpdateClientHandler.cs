using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class UpdateClientHandler
         : IRequestHandler<UpdateClientCommand, ClientDto>
    {
        private readonly IClientRepository _repo;

        public UpdateClientHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<ClientDto> Handle(
            UpdateClientCommand request,
            CancellationToken cancellationToken)
        {
            var client = await _repo.GetClientAsync(request.Id);

            if (client == null)
                throw new Exception("Client not found");

            client.CompanyName = request.Client.CompanyName;
            client.ContactPerson = request.Client.ContactPerson;
            client.Email = request.Client.Email;
            client.Phone = request.Client.Phone;
            client.Address = request.Client.Address;

            await _repo.UpdateClientAsync(client);
            return new ClientDto
            {
                Id = client.Id,
                CompanyName = client.CompanyName,
                ContactPerson = client.ContactPerson,
                Email = client.Email,
                Phone = client.Phone,
                Address = client.Address,
                ProjectCount = client.Projects.Count
            };
        }
    }
}
