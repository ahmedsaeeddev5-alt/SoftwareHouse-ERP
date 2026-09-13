using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repositories;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Expenses.Queries.GetExpenses;

public class GetExpensesHandler
    : IRequestHandler<GetExpensesQuery, IEnumerable<ExpenseReadDto>>
{
    private readonly IExpenseRepository _repository;

    public GetExpensesHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ExpenseReadDto>> Handle(
        GetExpensesQuery request,
        CancellationToken cancellationToken)
    {
        var expenses = await _repository.GetAllAsync();

        return expenses.Select(expense => new ExpenseReadDto
        {
            Id = expense.Id,
            ExpenseNumber = expense.ExpenseNumber,

            ProjectId = expense.ProjectId,
            ProjectName = expense.Project.Name,

            ExpenseDate = expense.ExpenseDate,
            Amount = expense.Amount,
            Currency = expense.Currency,
            Category = expense.Category,
            Description = expense.Description,
            Status = expense.Status,
            CreatedDate = expense.CreatedDate
        });
    }
}