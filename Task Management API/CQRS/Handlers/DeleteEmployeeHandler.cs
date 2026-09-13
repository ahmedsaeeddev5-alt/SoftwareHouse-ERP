using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Repository;

namespace Task_Management_API.CQRS.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _repo;

        public DeleteEmployeeHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result =
                await _repo.DeleteEmployeeAsync(request.Id);

            if (!result)
                throw new Exception("Employee not found");

            return true;
        }
    }
}
