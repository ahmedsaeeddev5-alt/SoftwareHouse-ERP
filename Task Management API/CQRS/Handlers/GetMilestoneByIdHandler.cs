using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetMilestoneByIdHandler : IRequestHandler<GetMilestoneByIdQuery, MilestoneDto>
    {
        private readonly IMilestoneRepository _repo;

        public GetMilestoneByIdHandler(
            IMilestoneRepository repo)
        {
            _repo = repo;
        }
        public async Task<MilestoneDto> Handle(GetMilestoneByIdQuery request, CancellationToken cancellationToken)
        {
            var milestone =
                await _repo.GetMilestoneAsync(request.Id);

            if (milestone == null)
                return null;

            return new MilestoneDto
            {
                Id = milestone.Id,
                Name = milestone.Name,
                Description = milestone.Description,
                StartDate = milestone.StartDate,
                DueDate = milestone.DueDate,
                Status = milestone.Status,
                ProjectId = milestone.ProjectId,
                ProjectName =
                    milestone.Project?.Name ?? string.Empty
            };
        }
    }
}
