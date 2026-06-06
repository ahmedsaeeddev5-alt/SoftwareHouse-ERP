using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Commands
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdQuery, TaskItemReadDto>
    {
        private readonly ITaskRepository _repo;

        public GetItemByIdHandler(ITaskRepository repo)
        {
            _repo = repo;
        }
        public async  Task<TaskItemReadDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _repo.GetItemAsync(request.Id);

            if (item == null)
                return null; // Controller هو اللي يقرر يرجع 404

            return new TaskItemReadDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                UserId = item.UserId,
                UserName = item.User?.UserName,
                ImageBase64 = item.Image != null
                    ? Convert.ToBase64String(item.Image)
                    : null
            };
        }
    }
}
    

