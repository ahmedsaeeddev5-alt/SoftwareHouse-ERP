using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class UpdateMilestoneHandler : IRequestHandler<UpdateMilestoneCommand, MilestoneDto>
    {
        private readonly IMilestoneRepository _repo;

        public UpdateMilestoneHandler(
            IMilestoneRepository repo)
        {
            _repo = repo;
        }

        public async Task<MilestoneDto> Handle(UpdateMilestoneCommand request, CancellationToken cancellationToken)
        {
            var milestone =
                 await _repo.GetMilestoneAsync(request.Id);

            if (milestone == null)
                throw new Exception("Milestone not found");

            milestone.Name = request.Milestone.Name;
            milestone.Description = request.Milestone.Description;
            milestone.StartDate = request.Milestone.StartDate;
            milestone.DueDate = request.Milestone.DueDate;
            milestone.Status = request.Milestone.Status;

            await _repo.UpdateMilestoneAsync(milestone);

            var updatedMilestone =
                await _repo.GetMilestoneAsync(milestone.Id);

            return new MilestoneDto
            {
                Id = updatedMilestone!.Id,
                Name = updatedMilestone.Name,
                Description = updatedMilestone.Description,
                StartDate = updatedMilestone.StartDate,
                DueDate = updatedMilestone.DueDate,
                Status = updatedMilestone.Status,
                ProjectId = updatedMilestone.ProjectId,
                ProjectName =
                    updatedMilestone.Project?.Name ?? string.Empty
            };
        }
    }
}
