using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, ProjectDto>
    {
        private readonly IProjectRepository _repo;

        public UpdateProjectHandler(IProjectRepository repo)
        {
            _repo = repo;
        }
        public async Task<ProjectDto> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project =
                 await _repo.GetProjectAsync(request.Id);

            if (project == null)
                throw new Exception("Project not found");

            project.Name = request.Project.Name;
            project.Description = request.Project.Description;
            project.StartDate = request.Project.StartDate;
            project.EndDate = request.Project.EndDate;
            project.Status = request.Project.Status;
            project.Budget = request.Project.Budget;
            project.ClientId = request.Project.ClientId;

            await _repo.UpdateProjectAsync(project);

            var updatedProject =
                await _repo.GetProjectAsync(project.Id);

            return new ProjectDto
            {
                Id = updatedProject!.Id,
                Name = updatedProject.Name,
                Description = updatedProject.Description,
                StartDate = updatedProject.StartDate,
                EndDate = updatedProject.EndDate,
                Status = updatedProject.Status,
                Budget = updatedProject.Budget,
                ClientId = updatedProject.ClientId,
                ClientName = updatedProject.Client.CompanyName,
                MemberCount = updatedProject.ProjectMembers.Count,
                TaskCount = updatedProject.Tasks.Count
            };
        }
    }
}
