using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Contracts.Commands.DeleteContract;

public class DeleteContractHandler
    : IRequestHandler<DeleteContractCommand, bool>
{
    private readonly IContractRepository _repository;

    public DeleteContractHandler(IContractRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteContractCommand request,
        CancellationToken cancellationToken)
    {
        var contract = await _repository.GetByIdAsync(request.Id);

        if (contract == null)
            return false;

        await _repository.DeleteAsync(request.Id);

        return true;
    }
}