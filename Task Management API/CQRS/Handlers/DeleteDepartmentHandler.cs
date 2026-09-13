using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        private readonly IDepartmentRepository _repo;

        public DeleteDepartmentHandler(
            IDepartmentRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var result =
                  await _repo.DeleteDepartmentAsync(request.Id);

            if (!result)
                throw new Exception("Department not found");

            return true;
        }
    }
}
