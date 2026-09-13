using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetClientByIdHandler
         : IRequestHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly IClientRepository _repo;

        public GetClientByIdHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<ClientDto> Handle(
            GetClientByIdQuery request,
            CancellationToken cancellationToken)
        {
            var client = await _repo.GetClientAsync(request.Id);

            if (client == null)
                return null;

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
