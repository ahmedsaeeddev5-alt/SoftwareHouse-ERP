using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetProjectDetailsHandler
        : IRequestHandler<GetProjectDetailsQuery, ProjectDetailsDto>
    {
        private readonly IProjectRepository _repo;

        public GetProjectDetailsHandler(IProjectRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProjectDetailsDto> Handle(
            GetProjectDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var project =
                await _repo.GetProjectDetailsAsync(request.Id);

            if (project == null)
                return null;

            return new ProjectDetailsDto
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

                Members = project.ProjectMembers
                    .Select(pm => new ProjectMemberDto
                    {
                        Id = pm.Id,
                        ProjectId = pm.ProjectId,
                        ProjectName = project.Name,
                        EmployeeId = pm.EmployeeId,
                        EmployeeName = pm.Employee.FullName,
                        Role = pm.Role,
                        AssignedDate = pm.AssignedDate
                    })
                    .ToList(),

                Tasks = project.Tasks
                    .Select(t => new ProjectTaskDto
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Status = t.Status,
                        Priority = t.Priority,
                        CreatedDate = t.CreatedDate,
                        DueDate = t.DueDate,
                        EmployeeId = t.EmployeeId,
                        EmployeeName = t.Employee != null
                            ? t.Employee.FullName
                            : null
                    })
                    .ToList()
            };
        }
    }
}