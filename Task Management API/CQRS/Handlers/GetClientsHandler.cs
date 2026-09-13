using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetClientsHandler
        : IRequestHandler<GetClientsQuery, List<ClientDto>>
    {
        private readonly IClientRepository _repo;

        public GetClientsHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ClientDto>> Handle(
            GetClientsQuery request,
            CancellationToken cancellationToken)
        {
            var clients = await _repo.GetClientsAsync();

            return clients.Select(client => new ClientDto
            {
                Id = client.Id,
                CompanyName = client.CompanyName,
                ContactPerson = client.ContactPerson,
                Email = client.Email,
                Phone = client.Phone,
                Address = client.Address,
                ProjectCount = client.Projects.Count
            }).ToList();
        }
    }
}
