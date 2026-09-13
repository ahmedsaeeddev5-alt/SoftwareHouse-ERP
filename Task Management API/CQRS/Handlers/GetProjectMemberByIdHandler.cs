using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetProjectMemberByIdHandler : IRequestHandler<GetProjectMemberByIdQuery, ProjectMemberDto>
    {
        private readonly IProjectMemberRepository _repo;

        public GetProjectMemberByIdHandler(
            IProjectMemberRepository repo)
        {
            _repo = repo;
        }
        public async Task<ProjectMemberDto> Handle(GetProjectMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var member =
               await _repo.GetMemberAsync(request.Id);

            if (member == null)
                return null;

            return new ProjectMemberDto
            {
                Id = member.Id,
                ProjectId = member.ProjectId,
                ProjectName = member.Project.Name,
                EmployeeId = member.EmployeeId,
                EmployeeName = member.Employee.FullName,
                Role = member.Role,
                AssignedDate = member.AssignedDate
            };
        }
    }
}
