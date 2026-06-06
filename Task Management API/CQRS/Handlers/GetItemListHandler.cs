using MediatR;
using Microsoft.EntityFrameworkCore;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetItemListHandler : IRequestHandler<GetAllItemsQuery, List<TaskItemReadDto>>
    {
        private readonly ITaskRepository _repo;

        public GetItemListHandler(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TaskItemReadDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _repo.GetItemsAsync();

            return tasks.Select(x => new TaskItemReadDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsCompleted = x.IsCompleted,
                UserId = x.UserId,
                UserName = x.User?.UserName,
                ImageBase64 = x.Image != null
                    ? Convert.ToBase64String(x.Image)
                    : null
            }).ToList();
        }
    }
}