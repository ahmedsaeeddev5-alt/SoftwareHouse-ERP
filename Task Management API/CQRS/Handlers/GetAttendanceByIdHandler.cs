using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repositories;

namespace Task_Management_API.Features.Attendance.Queries.GetAttendanceById;

public class GetAttendanceByIdHandler
    : IRequestHandler<GetAttendanceByIdQuery, AttendanceReadDto?>
{
    private readonly IAttendanceRepository _repository;

    public GetAttendanceByIdHandler(IAttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<AttendanceReadDto?> Handle(
        GetAttendanceByIdQuery request,
        CancellationToken cancellationToken)
    {
        var attendance = await _repository.GetByIdAsync(request.Id);

        if (attendance == null)
            return null;

        return new AttendanceReadDto
        {
            Id = attendance.Id,

            EmployeeId = attendance.EmployeeId,
            EmployeeName = attendance.Employee.FullName,

            AttendanceDate = attendance.AttendanceDate,
            CheckIn = attendance.CheckIn,
            CheckOut = attendance.CheckOut,
            Status = attendance.Status,
            Notes = attendance.Notes,
            CreatedDate = attendance.CreatedDate
        };
    }
}