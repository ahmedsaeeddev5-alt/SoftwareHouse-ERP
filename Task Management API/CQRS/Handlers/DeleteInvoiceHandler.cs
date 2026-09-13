using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Repositories;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Invoices.Commands.DeleteInvoice;

public class DeleteInvoiceHandler
    : IRequestHandler<DeleteInvoiceCommand, bool>
{
    private readonly IInvoiceRepository _repository;

    public DeleteInvoiceHandler(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteInvoiceCommand request,
        CancellationToken cancellationToken)
    {
        var invoice = await _repository.GetByIdAsync(request.Id);

        if (invoice == null)
            return false;

        await _repository.DeleteAsync(request.Id);

        return true;
    }
}