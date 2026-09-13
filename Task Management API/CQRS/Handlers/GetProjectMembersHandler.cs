using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetProjectMembersHandler : IRequestHandler<GetProjectMembersQuery, List<ProjectMemberDto>>
    {
        private readonly IProjectMemberRepository _repo;

        public GetProjectMembersHandler(
            IProjectMemberRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<ProjectMemberDto>> Handle(GetProjectMembersQuery request, CancellationToken cancellationToken)
        {
            var members =
              await _repo.GetMembersAsync(request.ProjectId);

            return members.Select(x => new ProjectMemberDto
            {
                Id = x.Id,
                ProjectId = x.ProjectId,
                ProjectName = x.Project.Name,
                EmployeeId = x.EmployeeId,
                EmployeeName = x.Employee.FullName,
                Role = x.Role,
                AssignedDate = x.AssignedDate
            }).ToList();
        }
    }
}
