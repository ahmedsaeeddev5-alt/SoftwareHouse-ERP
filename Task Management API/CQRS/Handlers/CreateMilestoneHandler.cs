using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Data.Models;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class CreateMilestoneHandler : IRequestHandler<CreateMilestoneCommand, MilestoneDto>
    {
        private readonly IMilestoneRepository _repo;

        public CreateMilestoneHandler(IMilestoneRepository repo)
        {
            _repo = repo;
        }
        public async Task<MilestoneDto> Handle(CreateMilestoneCommand request, CancellationToken cancellationToken)
        {
            var milestone = new Milestone
            {
                Name = request.Milestone.Name,
                Description = request.Milestone.Description,
                StartDate = request.Milestone.StartDate,
                DueDate = request.Milestone.DueDate,
                Status = request.Milestone.Status,
                ProjectId = request.Milestone.ProjectId
            };

            var result =
                await _repo.InsertMilestoneAsync(milestone);

            var createdMilestone =
                await _repo.GetMilestoneAsync(result.Id);

            return MapToDto(createdMilestone!);
        }

        private static MilestoneDto MapToDto(
            Milestone milestone)
        {
            return new MilestoneDto
            {
                Id = milestone.Id,
                Name = milestone.Name,
                Description = milestone.Description,
                StartDate = milestone.StartDate,
                DueDate = milestone.DueDate,
                Status = milestone.Status,
                ProjectId = milestone.ProjectId,
                ProjectName = milestone.Project?.Name ?? string.Empty
            };
        }
    }
}
