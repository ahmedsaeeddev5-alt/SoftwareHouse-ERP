using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Data.Models;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class InsertItemListHandler : IRequestHandler<InsertItemCommand, TaskItemReadDto>
    {
        private readonly ITaskRepository _repo;

        public InsertItemListHandler(ITaskRepository repo)
        {
            _repo = repo;
        }
        public async Task<TaskItemReadDto> Handle(InsertItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TaskItem
            {
                Title = request.Item.Title,

                Description = request.Item.Description,

                Status = request.Item.Status,

                Priority = request.Item.Priority,

                DueDate = request.Item.DueDate,

                ProjectId = request.Item.ProjectId,

                EmployeeId = request.Item.EmployeeId,

                UserId = request.UserId,

                CreatedDate = DateTime.UtcNow,

                Image = request.Item.Image != null
                    ? await ConvertToBytes(request.Item.Image)
                    : null
            };
            var result = await _repo.InsertItemAsync(entity);

            var createdTask =
                await _repo.GetItemAsync(result.Id);

            return MapToDto(createdTask!);
        }

        private static TaskItemReadDto MapToDto(TaskItem task)
        {
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

        private async Task<byte[]> ConvertToBytes(IFormFile file)
        {
            using var ms = new MemoryStream();

            await file.CopyToAsync(ms);

            return ms.ToArray();
        }
    }
}
