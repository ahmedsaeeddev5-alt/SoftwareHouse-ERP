using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Data.Models;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class CreateProjectMemberHandler : IRequestHandler<CreateProjectMemberCommand, ProjectMemberDto>
    {
        private readonly IProjectMemberRepository _repo;

        public CreateProjectMemberHandler(
            IProjectMemberRepository repo)
        {
            _repo = repo;
        }
        public async Task<ProjectMemberDto> Handle(CreateProjectMemberCommand request, CancellationToken cancellationToken)
        {
            var member = new ProjectMember
            {
                ProjectId = request.Member.ProjectId,
                EmployeeId = request.Member.EmployeeId,
                Role = request.Member.Role,
                AssignedDate = request.Member.AssignedDate
            };

            var result = await _repo.InsertMemberAsync(member);

            var createdMember =
                await _repo.GetMemberAsync(result.Id);

            return new ProjectMemberDto
            {
                Id = createdMember!.Id,
                ProjectId = createdMember.ProjectId,
                ProjectName = createdMember.Project.Name,
                EmployeeId = createdMember.EmployeeId,
                EmployeeName = createdMember.Employee.FullName,
                Role = createdMember.Role,
                AssignedDate = createdMember.AssignedDate
            };
        }
    }
}
