using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repositories;

namespace Task_Management_API.Features.Attendance.Queries.GetAttendances;

public class GetAttendancesHandler
    : IRequestHandler<GetAttendancesQuery, IEnumerable<AttendanceReadDto>>
{
    private readonly IAttendanceRepository _repository;

    public GetAttendancesHandler(IAttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AttendanceReadDto>> Handle(
        GetAttendancesQuery request,
        CancellationToken cancellationToken)
    {
        var attendances = await _repository.GetAllAsync();

        return attendances.Select(attendance => new AttendanceReadDto
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
        });
    }
}