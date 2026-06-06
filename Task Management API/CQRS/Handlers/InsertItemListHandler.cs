using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Data.Models;
using Task_Management_API.Repository;
using System.Security.Claims;
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
                IsCompleted = false,
                UserId = request.UserId,
                Image = request.Item.Image != null
               ? await ConvertToBytes(request.Item.Image)
               : null
            };

            var result = await _repo.InsertItemAsync(entity);

            return new TaskItemReadDto
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                IsCompleted = result.IsCompleted,
                UserId = result.UserId,
                ImageBase64 = result.Image != null
                    ? Convert.ToBase64String(result.Image)
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
    

    
