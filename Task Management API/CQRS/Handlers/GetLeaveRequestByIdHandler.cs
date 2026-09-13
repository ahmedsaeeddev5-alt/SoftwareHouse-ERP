using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.LeaveRequest.Queries.GetLeaveRequestById;

public class GetLeaveRequestByIdHandler
    : IRequestHandler<
        GetLeaveRequestByIdQuery,
        LeaveRequestReadDto?>
{
    private readonly ILeaveRequestRepository _repository;

    public GetLeaveRequestByIdHandler(
        ILeaveRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<LeaveRequestReadDto?> Handle(
        GetLeaveRequestByIdQuery request,
        CancellationToken cancellationToken)
    {
        var leaveRequest =
            await _repository.GetByIdAsync(request.Id);

        if (leaveRequest == null)
            return null;

        return new LeaveRequestReadDto
        {
            Id = leaveRequest.Id,

            EmployeeId = leaveRequest.EmployeeId,
            EmployeeName = leaveRequest.Employee.FullName,

            StartDate = leaveRequest.StartDate,
            EndDate = leaveRequest.EndDate,
            LeaveType = leaveRequest.LeaveType,
            Status = leaveRequest.Status,
            Reason = leaveRequest.Reason,
            Notes = leaveRequest.Notes,
            CreatedDate = leaveRequest.CreatedDate
        };
    }
}