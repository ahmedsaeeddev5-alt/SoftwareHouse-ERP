using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdQuery, TaskItemReadDto>
    {
        private readonly ITaskRepository _repo;

        public GetItemByIdHandler(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<TaskItemReadDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _repo.GetItemAsync(request.Id);

            if (task == null)
                return null;

            return new TaskItemReadDto
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
            };
        }
    }
}
