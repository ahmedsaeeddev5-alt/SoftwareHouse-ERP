using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployeeRepository _repo;

        public UpdateEmployeeHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee =
                 await _repo.GetEmployeeAsync(request.Id);

            if (employee == null)
                throw new Exception("Employee not found");

            employee.EmployeeNumber =
                request.Employee.EmployeeNumber;

            employee.FullName =
                request.Employee.FullName;

            employee.Phone =
                request.Employee.Phone;

            employee.HireDate =
                request.Employee.HireDate;

            employee.Salary =
                request.Employee.Salary;

            employee.DepartmentId =
                request.Employee.DepartmentId;

            employee.UserId =
                request.Employee.UserId;

            await _repo.UpdateEmployeeAsync(employee);
            var updatedEmployee =
                await _repo.GetEmployeeAsync(employee.Id);

            return new EmployeeDto
            {
                Id = updatedEmployee!.Id,
                EmployeeNumber = updatedEmployee.EmployeeNumber,
                FullName = updatedEmployee.FullName,
                Phone = updatedEmployee.Phone,
                HireDate = updatedEmployee.HireDate,
                Salary = updatedEmployee.Salary,
                DepartmentId = updatedEmployee.DepartmentId,
                DepartmentName = updatedEmployee.Department.Name,
                UserId = updatedEmployee.UserId,
                UserName = updatedEmployee.User?.UserName
            };
        }
    }
}
