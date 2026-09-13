using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.LeaveRequest.Queries.GetLeaveRequests;

public class GetLeaveRequestsHandler
    : IRequestHandler<
        GetLeaveRequestsQuery,
        IEnumerable<LeaveRequestReadDto>>
{
    private readonly ILeaveRequestRepository _repository;

    public GetLeaveRequestsHandler(
        ILeaveRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<LeaveRequestReadDto>> Handle(
        GetLeaveRequestsQuery request,
        CancellationToken cancellationToken)
    {
        var leaveRequests =
            await _repository.GetAllAsync();

        return leaveRequests.Select(leaveRequest =>
            new LeaveRequestReadDto
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
            });
    }
}