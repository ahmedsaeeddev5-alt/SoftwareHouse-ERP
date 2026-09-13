using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, bool>
    {
        private readonly IProjectRepository _repo;

        public DeleteProjectHandler(IProjectRepository repo)
        {
            _repo = repo;
        }

        public async  Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var result =
               await _repo.DeleteProjectAsync(request.Id);

            if (!result)
                throw new Exception("Project not found");

            return true;
        }
    }
}
