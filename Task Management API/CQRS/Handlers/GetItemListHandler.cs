using MediatR;
using Task_Management_API.CQRS.Queries;
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

            return tasks.Select(task => new TaskItemReadDto
            {
                Id = task.Id,

                Title = task.Title,

                Description = task.Description,

                Status = task.Status,

                Priority = task.Priority,

                CreatedDate = task.CreatedDate,

                DueDate = task.DueDate,

                ProjectId = task.ProjectId,

                ProjectName = task.Project?.Name,

                EmployeeId = task.EmployeeId,

                EmployeeName = task.Employee?.FullName,

                UserId = task.UserId,
                UserName = task.User?.UserName,

                ImageBase64 = task.Image != null
                    ? Convert.ToBase64String(task.Image)
                    : null

            }).ToList();
        }
    }
}
