using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repositories;

namespace Task_Management_API.Features.Attendance.Commands.CreateAttendance;

public class CreateAttendanceHandler
    : IRequestHandler<CreateAttendanceCommand, AttendanceReadDto>
{
    private readonly IAttendanceRepository _repository;

    public CreateAttendanceHandler(IAttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<AttendanceReadDto> Handle(
        CreateAttendanceCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.Attendance;

        var attendance = new Task_Management_API.Data.Models.Attendance
        {
            EmployeeId = dto.EmployeeId,
            AttendanceDate = dto.AttendanceDate,
            CheckIn = dto.CheckIn,
            CheckOut = dto.CheckOut,
            Status = dto.Status,
            Notes = dto.Notes
        };

        var createdAttendance = await _repository.AddAsync(attendance);

        var result = await _repository.GetByIdAsync(createdAttendance.Id);

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