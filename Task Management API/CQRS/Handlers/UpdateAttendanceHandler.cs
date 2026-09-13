using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repositories;

namespace Task_Management_API.Features.Attendance.Commands.UpdateAttendance;

public class UpdateAttendanceHandler
    : IRequestHandler<UpdateAttendanceCommand, AttendanceReadDto?>
{
    private readonly IAttendanceRepository _repository;

    public UpdateAttendanceHandler(IAttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<AttendanceReadDto?> Handle(
        UpdateAttendanceCommand request,
        CancellationToken cancellationToken)
    {
        var attendance = await _repository.GetByIdAsync(request.Id);

        if (attendance == null)
            return null;

        var dto = request.Attendance;

        attendance.EmployeeId = dto.EmployeeId;
        attendance.AttendanceDate = dto.AttendanceDate;
        attendance.CheckIn = dto.CheckIn;
        attendance.CheckOut = dto.CheckOut;
        attendance.Status = dto.Status;
        attendance.Notes = dto.Notes;

        await _repository.UpdateAsync(attendance);

        var result = await _repository.GetByIdAsync(attendance.Id);

        return new AttendanceReadDto
        {
            Id = result!.Id,

            EmployeeId = result.EmployeeId,
            EmployeeName = result.Employee.FullName,

            AttendanceDate = result.AttendanceDate,
            CheckIn = result.CheckIn,
            CheckOut = result.CheckOut,
            Status = result.Status,
            Notes = result.Notes,
            CreatedDate = result.CreatedDate
        };
    }
}