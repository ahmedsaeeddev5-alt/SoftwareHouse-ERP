using MediatR;

namespace Task_Management_API.CQRS.Commands
{
    public record ReassignEmployeeDepartmentCommand(
        int EmployeeId,
        int DepartmentId
    ) : IRequest<bool>;
}
