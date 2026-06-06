using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemCommand, bool>
    {
        private readonly ITaskRepository _repo;

        public DeleteItemHandler(ITaskRepository repo)
        {
            _repo = repo;
        }
        public async  Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var result = await _repo.DeleteItemAsync(request.Id);

            if (!result)
                throw new Exception("Task not found");

            return true;
        }
    }
}
