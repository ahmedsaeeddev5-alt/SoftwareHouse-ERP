using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetProjectsHandler : IRequestHandler<GetProjectsQuery, List<ProjectDto>>
    {
        private readonly IProjectRepository _repo;

        public GetProjectsHandler(IProjectRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<ProjectDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repo.GetProjectsAsync();

            return projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Status = p.Status,
                Budget = p.Budget,
                ClientId = p.ClientId,
                ClientName = p.Client.CompanyName,
                MemberCount = p.ProjectMembers.Count,
                TaskCount = p.Tasks.Count
            }).ToList();
        }
    }
}
