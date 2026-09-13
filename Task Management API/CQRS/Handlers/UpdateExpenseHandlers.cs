using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repositories;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Expenses.Commands.UpdateExpense;

public class UpdateExpenseHandler
    : IRequestHandler<UpdateExpenseCommand, ExpenseReadDto?>
{
    private readonly IExpenseRepository _repository;

    public UpdateExpenseHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<ExpenseReadDto?> Handle(
        UpdateExpenseCommand request,
        CancellationToken cancellationToken)
    {
        var expense = await _repository.GetByIdAsync(request.Id);

        if (expense == null)
            return null;

        var dto = request.Expense;

        expense.ExpenseNumber = dto.ExpenseNumber;
        expense.ProjectId = dto.ProjectId;
        expense.ExpenseDate = dto.ExpenseDate;
        expense.Amount = dto.Amount;
        expense.Currency = dto.Currency;
        expense.Category = dto.Category;
        expense.Description = dto.Description;
        expense.Status = dto.Status;

        await _repository.UpdateAsync(expense);

        var result = await _repository.GetByIdAsync(expense.Id);

        return new ExpenseReadDto
        {
            Id = result!.Id,
            ExpenseNumber = result.ExpenseNumber,

            ProjectId = result.ProjectId,
            ProjectName = result.Project.Name,

            ExpenseDate = result.ExpenseDate,
            Amount = result.Amount,
            Currency = result.Currency,
            Category = result.Category,
            Description = result.Description,
            Status = result.Status,
            CreatedDate = result.CreatedDate
        };
    }
}