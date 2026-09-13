using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Data.Models;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, DepartmentDto>
    {
        private readonly IDepartmentRepository _repo;

        public CreateDepartmentHandler(
            IDepartmentRepository repo)
        {
            _repo = repo;
        }
        public  async Task<DepartmentDto> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department
            {
                Name = request.Department.Name,
                Description = request.Department.Description
            };

            var result =
                await _repo.InsertDepartmentAsync(department);

            return new DepartmentDto
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                EmployeeCount = 0
            };
        }
    }
}

