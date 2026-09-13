using MediatR;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.CQRS.Queries
{
    public record GetExpensesQuery
    : IRequest<IEnumerable<ExpenseReadDto>>;
}
