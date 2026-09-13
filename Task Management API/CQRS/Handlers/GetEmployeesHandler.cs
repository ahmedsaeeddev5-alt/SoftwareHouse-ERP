using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeDto>>
    {
        private readonly IEmployeeRepository _repo;

        public GetEmployeesHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees =
               await _repo.GetEmployeesAsync();

            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                EmployeeNumber = e.EmployeeNumber,
                FullName = e.FullName,
                Phone = e.Phone,
                HireDate = e.HireDate,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department.Name,
                UserId = e.UserId,
                UserName = e.User?.UserName
            }).ToList();
        }
    }
}
