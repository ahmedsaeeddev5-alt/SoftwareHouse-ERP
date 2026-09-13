using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetMilestonesHandler : IRequestHandler<GetMilestonesQuery, List<MilestoneDto>>
    {
        private readonly IMilestoneRepository _repo;

        public GetMilestonesHandler(IMilestoneRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<MilestoneDto>> Handle(GetMilestonesQuery request, CancellationToken cancellationToken)
        {
            var milestones =
                 await _repo.GetMilestonesAsync(request.ProjectId);

            return milestones.Select(m => new MilestoneDto
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                StartDate = m.StartDate,
                DueDate = m.DueDate,
                Status = m.Status,
                ProjectId = m.ProjectId,
                ProjectName = m.Project?.Name ?? string.Empty
            }).ToList();
        }
    }
}
