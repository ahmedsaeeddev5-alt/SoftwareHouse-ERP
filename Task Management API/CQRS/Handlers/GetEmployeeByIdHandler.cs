using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IEmployeeRepository _repo;

        public GetEmployeeByIdHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee =
               await _repo.GetEmployeeAsync(request.Id);

            if (employee == null)
                return null;

            return new EmployeeDto
            {
                Id = employee.Id,
                EmployeeNumber = employee.EmployeeNumber,
                FullName = employee.FullName,
                Phone = employee.Phone,
                HireDate = employee.HireDate,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department.Name,
                UserId = employee.UserId,
                UserName = employee.User?.UserName
            };
        }
    }
}
