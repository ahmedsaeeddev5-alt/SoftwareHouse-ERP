using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IDepartmentRepository _repo;

        public GetDepartmentByIdHandler(
            IDepartmentRepository repo)
        {
            _repo = repo;
        }
        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department =
                await _repo.GetDepartmentAsync(request.Id);

            if (department == null)
                return null;

            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                EmployeeCount = department.Employees.Count
            };
        }
    }
}
