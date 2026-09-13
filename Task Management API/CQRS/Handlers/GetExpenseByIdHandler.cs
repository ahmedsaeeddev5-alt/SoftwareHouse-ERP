using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repositories;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Expenses.Queries.GetExpenseById;

public class GetExpenseByIdHandler
    : IRequestHandler<GetExpenseByIdQuery, ExpenseReadDto?>
{
    private readonly IExpenseRepository _repository;

    public GetExpenseByIdHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<ExpenseReadDto?> Handle(
        GetExpenseByIdQuery request,
        CancellationToken cancellationToken)
    {
        var expense = await _repository.GetByIdAsync(request.Id);

        if (expense == null)
            return null;

        return new ExpenseReadDto
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
        };
    }
}