using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class DeleteClientHandler
         : IRequestHandler<DeleteClientCommand, bool>
    {
        private readonly IClientRepository _repo;

        public DeleteClientHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(
            DeleteClientCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _repo.DeleteClientAsync(request.Id);

            if (!result)
                throw new Exception("Client not found");

            return true;
        }
    }
}
