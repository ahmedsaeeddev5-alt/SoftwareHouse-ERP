using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Data.Models;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, ProjectDto>
    {
        private readonly IProjectRepository _repo;

        public CreateProjectHandler(IProjectRepository repo)
        {
            _repo = repo;
        }
        public async Task<ProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Name = request.Project.Name,
                Description = request.Project.Description,
                StartDate = request.Project.StartDate,
                EndDate = request.Project.EndDate,
                Status = request.Project.Status,
                Budget = request.Project.Budget,
                ClientId = request.Project.ClientId
            };

            var result = await _repo.InsertProjectAsync(project);

            var createdProject =
                await _repo.GetProjectAsync(result.Id);

            return new ProjectDto
            {
                Id = createdProject!.Id,
                Name = createdProject.Name,
                Description = createdProject.Description,
                StartDate = createdProject.StartDate,
                EndDate = createdProject.EndDate,
                Status = createdProject.Status,
                Budget = createdProject.Budget,
                ClientId = createdProject.ClientId,
                ClientName = createdProject.Client.CompanyName,
                MemberCount = createdProject.ProjectMembers.Count,
                TaskCount = createdProject.Tasks.Count
            };
        }
    }
}
