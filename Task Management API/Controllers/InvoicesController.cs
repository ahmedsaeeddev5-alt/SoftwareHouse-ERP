using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public InvoicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Invoices
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InvoiceReadDto>>> GetInvoices()
    {
        var invoices = await _mediator.Send(new GetInvoicesQuery());

        return Ok(invoices);
    }

    // GET: api/Invoices/5
    [HttpGet("{id}")]
    public async Task<ActionResult<InvoiceReadDto>> GetInvoiceById(int id)
    {
        var invoice = await _mediator.Send(
            new GetInvoiceByIdQuery(id));

        if (invoice == null)
        {
            return NotFound(new
            {
                message = "Invoice not found."
            });
        }

        return Ok(invoice);
    }

    // POST: api/Invoices
    [HttpPost]
    public async Task<ActionResult<InvoiceReadDto>> CreateInvoice(
        [FromBody] InvoiceCreateDto dto)
    {
        var invoice = await _mediator.Send(
            new CreateInvoiceCommand(dto));

        return CreatedAtAction(
            nameof(GetInvoiceById),
            new { id = invoice.Id },
            invoice);
    }

    // PUT: api/Invoices/5
    [HttpPut("{id}")]
    public async Task<ActionResult<InvoiceReadDto>> UpdateInvoice(
        int id,
        [FromBody] InvoiceCreateDto dto)
    {
        var invoice = await _mediator.Send(
            new UpdateInvoiceCommand(id, dto));

        if (invoice == null)
        {
            return NotFound(new
            {
                message = "Invoice not found."
            });
        }

        return Ok(invoice);
    }

    // DELETE: api/Invoices/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        var result = await _mediator.Send(
            new DeleteInvoiceCommand(id));

        if (!result)
        {
            return NotFound(new
            {
                message = "Invoice not found."
            });
        }

        return NoContent();
    }
}