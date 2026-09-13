using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class DeleteMilestoneHandler : IRequestHandler<DeleteMilestoneCommand, bool>
    {
        private readonly IMilestoneRepository _repo;

        public DeleteMilestoneHandler(
            IMilestoneRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(DeleteMilestoneCommand request, CancellationToken cancellationToken)
        {
            var result =
                 await _repo.DeleteMilestoneAsync(request.Id);

            if (!result)
                throw new Exception("Milestone not found");

            return true;
        }
    }
}
