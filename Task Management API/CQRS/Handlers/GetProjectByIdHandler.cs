using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public  class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ProjectDto>
    {
        private readonly IProjectRepository _repo;

        public GetProjectByIdHandler(IProjectRepository repo)
        {
            _repo = repo;
        }
        public async Task<ProjectDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project =
               await _repo.GetProjectAsync(request.Id);

            if (project == null)
                return null;

            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Status = project.Status,
                Budget = project.Budget,
                ClientId = project.ClientId,
                ClientName = project.Client.CompanyName,
                MemberCount = project.ProjectMembers.Count,
                TaskCount = project.Tasks.Count
            };
        }
    }
}
