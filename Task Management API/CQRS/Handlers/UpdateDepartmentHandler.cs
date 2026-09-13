using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, DepartmentDto>
    {
        private readonly IDepartmentRepository _repo;

        public UpdateDepartmentHandler(
            IDepartmentRepository repo)
        {
            _repo = repo;
        }
        public async Task<DepartmentDto> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department =
                await _repo.GetDepartmentAsync(request.Id);

            if (department == null)
                throw new Exception("Department not found");

            department.Name = request.Department.Name;
            department.Description =
                request.Department.Description;

            await _repo.UpdateDepartmentAsync(department);

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
