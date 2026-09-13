using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Payments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentReadDto>>> GetPayments()
    {
        var payments = await _mediator.Send(new GetPaymentsQuery());

        return Ok(payments);
    }

    // GET: api/Payments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentReadDto>> GetPaymentById(int id)
    {
        var payment = await _mediator.Send(
            new GetPaymentByIdQuery(id));

        if (payment == null)
        {
            return NotFound(new
            {
                message = "Payment not found."
            });
        }

        return Ok(payment);
    }

    // POST: api/Payments
    [HttpPost]
    public async Task<ActionResult<PaymentReadDto>> CreatePayment(
        [FromBody] PaymentCreateDto dto)
    {
        var payment = await _mediator.Send(
            new CreatePaymentCommand(dto));

        return CreatedAtAction(
            nameof(GetPaymentById),
            new { id = payment.Id },
            payment);
    }

    // PUT: api/Payments/5
    [HttpPut("{id}")]
    public async Task<ActionResult<PaymentReadDto>> UpdatePayment(
        int id,
        [FromBody] PaymentCreateDto dto)
    {
        var payment = await _mediator.Send(
            new UpdatePaymentCommand(id, dto));

        if (payment == null)
        {
            return NotFound(new
            {
                message = "Payment not found."
            });
        }

        return Ok(payment);
    }

    // DELETE: api/Payments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        var result = await _mediator.Send(
            new DeletePaymentCommand(id));

        if (!result)
        {
            return NotFound(new
            {
                message = "Payment not found."
            });
        }

        return NoContent();
    }
}