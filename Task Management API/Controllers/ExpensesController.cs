using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExpensesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Expenses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseReadDto>>> GetExpenses()
    {
        var expenses = await _mediator.Send(new GetExpensesQuery());

        return Ok(expenses);
    }

    // GET: api/Expenses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseReadDto>> GetExpenseById(int id)
    {
        var expense = await _mediator.Send(
            new GetExpenseByIdQuery(id));

        if (expense == null)
        {
            return NotFound(new
            {
                message = "Expense not found."
            });
        }

        return Ok(expense);
    }

    // POST: api/Expenses
    [HttpPost]
    public async Task<ActionResult<ExpenseReadDto>> CreateExpense(
        [FromBody] ExpenseCreateDto dto)
    {
        var expense = await _mediator.Send(
            new CreateExpenseCommand(dto));

        return CreatedAtAction(
            nameof(GetExpenseById),
            new { id = expense.Id },
            expense);
    }

    // PUT: api/Expenses/5
    [HttpPut("{id}")]
    public async Task<ActionResult<ExpenseReadDto>> UpdateExpense(
        int id,
        [FromBody] ExpenseCreateDto dto)
    {
        var expense = await _mediator.Send(
            new UpdateExpenseCommand(id, dto));

        if (expense == null)
        {
            return NotFound(new
            {
                message = "Expense not found."
            });
        }

        return Ok(expense);
    }

    // DELETE: api/Expenses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
        var result = await _mediator.Send(
            new DeleteExpenseCommand(id));

        if (!result)
        {
            return NotFound(new
            {
                message = "Expense not found."
            });
        }

        return NoContent();
    }
}