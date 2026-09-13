using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestHandler
    : IRequestHandler<CreateLeaveRequestCommand, LeaveRequestReadDto>
{
    private readonly ILeaveRequestRepository _repository;

    public CreateLeaveRequestHandler(ILeaveRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<LeaveRequestReadDto> Handle(
        CreateLeaveRequestCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.LeaveRequest;

        var leaveRequest = new Task_Management_API.Data.Models.LeaveRequest
        {
            EmployeeId = dto.EmployeeId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            LeaveType = dto.LeaveType,
            Status = dto.Status,
            Reason = dto.Reason,
            Notes = dto.Notes
        };

        var createdLeaveRequest =
            await _repository.AddAsync(leaveRequest);

        var result =
            await _repository.GetByIdAsync(createdLeaveRequest.Id);

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