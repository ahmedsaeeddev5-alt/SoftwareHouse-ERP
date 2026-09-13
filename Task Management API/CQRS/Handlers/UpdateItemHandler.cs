using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemCommand, TaskItemReadDto>
    {
        private readonly ITaskRepository _repo;

        public UpdateItemHandler(ITaskRepository repo)
        {
            _repo = repo;
        }
        public async Task<TaskItemReadDto> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetItemAsync(request.Id);

            if (existing == null)
                throw new Exception("Task not found");

            existing.Title = request.Item.Title;

            existing.Description = request.Item.Description;

            existing.Status = request.Item.Status;

            existing.Priority = request.Item.Priority;

            existing.DueDate = request.Item.DueDate;

            existing.ProjectId = request.Item.ProjectId;

            existing.EmployeeId = request.Item.EmployeeId;

            if (request.Item.Image != null)
            {
                existing.Image =
                    await ConvertToBytes(request.Item.Image);
            }
            await _repo.UpdateItemAsync(existing);

            var updatedTask =
                await _repo.GetItemAsync(existing.Id);

            return new TaskItemReadDto
            {
                Id = updatedTask!.Id,

                Title = updatedTask.Title,

                Description = updatedTask.Description,

                Status = updatedTask.Status,

                Priority = updatedTask.Priority,

                CreatedDate = updatedTask.CreatedDate,

                DueDate = updatedTask.DueDate,

                ProjectId = updatedTask.ProjectId,

                ProjectName = updatedTask.Project?.Name,

                EmployeeId = updatedTask.EmployeeId,
                EmployeeName = updatedTask.Employee?.FullName,

                UserId = updatedTask.UserId,

                UserName = updatedTask.User?.UserName,

                ImageBase64 = updatedTask.Image != null
                    ? Convert.ToBase64String(updatedTask.Image)
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
