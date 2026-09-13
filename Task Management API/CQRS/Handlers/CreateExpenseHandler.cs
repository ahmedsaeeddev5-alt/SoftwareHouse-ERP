using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Data.Models;
using Task_Management_API.Repositories;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Expenses.Commands.CreateExpense;

public class CreateExpenseHandler
    : IRequestHandler<CreateExpenseCommand, ExpenseReadDto>
{
    private readonly IExpenseRepository _repository;

    public CreateExpenseHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<ExpenseReadDto> Handle(
        CreateExpenseCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.Expense;

        var expense = new Expense
        {
            ExpenseNumber = dto.ExpenseNumber,
            ProjectId = dto.ProjectId,
            ExpenseDate = dto.ExpenseDate,
            Amount = dto.Amount,
            Currency = dto.Currency,
            Category = dto.Category,
            Description = dto.Description,
            Status = dto.Status
        };

        var createdExpense = await _repository.AddAsync(expense);

        var result = await _repository.GetByIdAsync(createdExpense.Id);

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