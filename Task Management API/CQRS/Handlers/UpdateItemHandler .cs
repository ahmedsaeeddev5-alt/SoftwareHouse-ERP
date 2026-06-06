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

            // تحديث البيانات
            existing.Title = request.Item.Title;
            existing.Description = request.Item.Description;
            existing.UserId = request.Item.UserId;

            if (request.Item.Image != null)
            {
                existing.Image = await ConvertToBytes(request.Item.Image);
            }

            await _repo.UpdateItemAsync(existing);

            return new TaskItemReadDto
            {
                Id = existing.Id,
                Title = existing.Title,
                Description = existing.Description,
                IsCompleted = existing.IsCompleted,
                UserId = existing.UserId,
                UserName = existing.User?.UserName,
                ImageBase64 = existing.Image != null
                    ? Convert.ToBase64String(existing.Image)
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
    

