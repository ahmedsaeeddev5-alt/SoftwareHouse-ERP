using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class UpdateProjectMemberHandler : IRequestHandler<UpdateProjectMemberCommand, ProjectMemberDto>
    {
        private readonly IProjectMemberRepository _repo;

        public UpdateProjectMemberHandler(
            IProjectMemberRepository repo)
        {
            _repo = repo;
        }
        public async Task<ProjectMemberDto> Handle(UpdateProjectMemberCommand request, CancellationToken cancellationToken)
        {
            var member =
                await _repo.GetMemberAsync(request.Id);

            if (member == null)
                throw new Exception("Project member not found");

            member.EmployeeId = request.Member.EmployeeId;
            member.Role = request.Member.Role;
            member.AssignedDate = request.Member.AssignedDate;

            await _repo.UpdateMemberAsync(member);

            var updatedMember =
                await _repo.GetMemberAsync(member.Id);

            return new ProjectMemberDto
            {
                Id = updatedMember!.Id,
                ProjectId = updatedMember.ProjectId,
                ProjectName = updatedMember.Project.Name,
                EmployeeId = updatedMember.EmployeeId,
                EmployeeName = updatedMember.Employee.FullName,
                Role = updatedMember.Role,
                AssignedDate = updatedMember.AssignedDate
            };
        }
    }
}
