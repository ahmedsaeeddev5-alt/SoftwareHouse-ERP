using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Repositories;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Expenses.Commands.DeleteExpense;

public class DeleteExpenseHandler
    : IRequestHandler<DeleteExpenseCommand, bool>
{
    private readonly IExpenseRepository _repository;

    public DeleteExpenseHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteExpenseCommand request,
        CancellationToken cancellationToken)
    {
        var expense = await _repository.GetByIdAsync(request.Id);

        if (expense == null)
            return false;

        await _repository.DeleteAsync(request.Id);

        return true;
    }
}