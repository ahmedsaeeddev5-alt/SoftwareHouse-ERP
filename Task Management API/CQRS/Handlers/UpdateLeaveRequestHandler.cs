using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestHandler
    : IRequestHandler<UpdateLeaveRequestCommand, LeaveRequestReadDto?>
{
    private readonly ILeaveRequestRepository _repository;

    public UpdateLeaveRequestHandler(ILeaveRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<LeaveRequestReadDto?> Handle(
        UpdateLeaveRequestCommand request,
        CancellationToken cancellationToken)
    {
        var leaveRequest =
            await _repository.GetByIdAsync(request.Id);

        if (leaveRequest == null)
            return null;

        var dto = request.LeaveRequest;

        leaveRequest.EmployeeId = dto.EmployeeId;
        leaveRequest.StartDate = dto.StartDate;
        leaveRequest.EndDate = dto.EndDate;
        leaveRequest.LeaveType = dto.LeaveType;
        leaveRequest.Status = dto.Status;
        leaveRequest.Reason = dto.Reason;
        leaveRequest.Notes = dto.Notes;

        await _repository.UpdateAsync(leaveRequest);

        var result =
            await _repository.GetByIdAsync(leaveRequest.Id);

        return new LeaveRequestReadDto
        {
            Id = result!.Id,

            EmployeeId = result.EmployeeId,
            EmployeeName = result.Employee.FullName,

            StartDate = result.StartDate,
            EndDate = result.EndDate,
            LeaveType = result.LeaveType,
            Status = result.Status,
            Reason = result.Reason,
            Notes = result.Notes,
            CreatedDate = result.CreatedDate
        };
    }
}