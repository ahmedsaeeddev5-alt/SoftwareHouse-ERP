using MediatR;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Data.Models;

namespace Task_Management_API.CQRS.Queries
{
    public record GetAllItemsQuery : IRequest<List<TaskItemReadDto>>;
}


