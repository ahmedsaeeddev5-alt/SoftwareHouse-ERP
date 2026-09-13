using MediatR;
using Microsoft.EntityFrameworkCore;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data;

namespace Task_Management_API.CQRS.Handlers
{
    public class ReassignEmployeeDepartmentHandler
        : IRequestHandler<ReassignEmployeeDepartmentCommand, bool>
    {
        private readonly AppDbContext _db;

        public ReassignEmployeeDepartmentHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(
            ReassignEmployeeDepartmentCommand request,
            CancellationToken cancellationToken)
        {
            var employee = await _db.Employees
                .FirstOrDefaultAsync(
                    e => e.Id == request.EmployeeId,
                    cancellationToken);

            if (employee == null)
                return false;

            var departmentExists = await _db.Departments
                .AnyAsync(
                    d => d.Id == request.DepartmentId,
                    cancellationToken);

            if (!departmentExists)
                return false;

            employee.DepartmentId = request.DepartmentId;

            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}