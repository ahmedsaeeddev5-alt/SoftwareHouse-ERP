using MediatR;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.CQRS.Commands
{
    public record UpdateEmployeeCommand(
        int Id,
        UpdateEmployeeDto Employee)
        : IRequest<EmployeeDto>;
}
