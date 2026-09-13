using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.LeaveRequest.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestHandler
    : IRequestHandler<DeleteLeaveRequestCommand, bool>
{
    private readonly ILeaveRequestRepository _repository;

    public DeleteLeaveRequestHandler(
        ILeaveRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteLeaveRequestCommand request,
        CancellationToken cancellationToken)
    {
        var leaveRequest =
            await _repository.GetByIdAsync(request.Id);

        if (leaveRequest == null)
            return false;

        await _repository.DeleteAsync(request.Id);

        return true;
    }
}