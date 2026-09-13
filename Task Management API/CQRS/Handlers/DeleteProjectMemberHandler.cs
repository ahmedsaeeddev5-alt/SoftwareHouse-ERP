using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class DeleteProjectMemberHandler : IRequestHandler<DeleteProjectMemberCommand, bool>
    {
        private readonly IProjectMemberRepository _repo;

        public DeleteProjectMemberHandler(
            IProjectMemberRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(DeleteProjectMemberCommand request, CancellationToken cancellationToken)
        {
            var result =
                await _repo.DeleteMemberAsync(request.Id);

            if (!result)
                throw new Exception(
                    "Project member not found");

            return true;
        }
    }
}
