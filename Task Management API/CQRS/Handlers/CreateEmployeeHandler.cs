using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Data.Models;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployeeRepository _repo;

        public CreateEmployeeHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        } 
        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                EmployeeNumber = request.Employee.EmployeeNumber,
                FullName = request.Employee.FullName,
                Phone = request.Employee.Phone,
                HireDate = request.Employee.HireDate,
                Salary = request.Employee.Salary,
                DepartmentId = request.Employee.DepartmentId,
                UserId = request.Employee.UserId
            };

            var result =
                await _repo.InsertEmployeeAsync(employee);

            var createdEmployee =
                await _repo.GetEmployeeAsync(result.Id);
            return new EmployeeDto
            {
                Id = createdEmployee!.Id,
                EmployeeNumber = createdEmployee.EmployeeNumber,
                FullName = createdEmployee.FullName,
                Phone = createdEmployee.Phone,
                HireDate = createdEmployee.HireDate,
                Salary = createdEmployee.Salary,
                DepartmentId = createdEmployee.DepartmentId,
                DepartmentName = createdEmployee.Department.Name,
                UserId = createdEmployee.UserId,
                UserName = createdEmployee.User?.UserName
            };
        }
    }
}
