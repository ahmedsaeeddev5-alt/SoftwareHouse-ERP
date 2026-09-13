using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetDepartmentsHandler
        : IRequestHandler<GetDepartmentsQuery, List<DepartmentDto>>
    {
        private readonly IDepartmentRepository _repo;

        public GetDepartmentsHandler(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<DepartmentDto>> Handle(
            GetDepartmentsQuery request,
            CancellationToken cancellationToken)
        {
            var departments = await _repo.GetDepartmentsAsync();

            return departments.Select(d => new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,

                EmployeeCount = d.Employees.Count,

                Employees = d.Employees
                    .Select(e => new DepartmentEmployeeDto
                    {
                        Id = e.Id,
                        EmployeeNumber = e.EmployeeNumber,
                        FullName = e.FullName,
                        Phone = e.Phone
                    })
                    .ToList()

            }).ToList();
        }
    }
}