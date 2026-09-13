using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Repositories;

namespace Task_Management_API.Features.Attendance.Commands.DeleteAttendance;

public class DeleteAttendanceHandler
    : IRequestHandler<DeleteAttendanceCommand, bool>
{
    private readonly IAttendanceRepository _repository;

    public DeleteAttendanceHandler(IAttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteAttendanceCommand request,
        CancellationToken cancellationToken)
    {
        var attendance = await _repository.GetByIdAsync(request.Id);

        if (attendance == null)
            return false;

        await _repository.DeleteAsync(request.Id);

        return true;
    }
}