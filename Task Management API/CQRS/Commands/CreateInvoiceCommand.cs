using MediatR;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.CQRS.Commands
{
    public record CreateInvoiceCommand(
     InvoiceCreateDto Invoice
 ) : IRequest<InvoiceReadDto>;
}
