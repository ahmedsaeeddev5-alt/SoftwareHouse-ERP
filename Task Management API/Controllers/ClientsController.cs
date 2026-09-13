using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<List<ClientDto>>> GetClients()
        {
            var result = await _mediator.Send(new GetClientsQuery());

            return Ok(result);
        }

        // GET: api/Clients/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClientDto>> GetClient(int id)
        {
            var result = await _mediator.Send(
                new GetClientByIdQuery(id));

            if (result == null)
                return NotFound(new
                {
                    message = "Client not found"
                });

            return Ok(result);
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<ClientDto>> CreateClient(
            CreateClientDto dto)
        {
            var result = await _mediator.Send(
                new CreateClientCommand(dto));

            return CreatedAtAction(
                nameof(GetClient),
                new { id = result.Id },
                result);
        }

        // PUT: api/Clients/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ClientDto>> UpdateClient(
            int id,
            UpdateClientDto dto)
        {
            var result = await _mediator.Send(
                new UpdateClientCommand(id, dto));

            return Ok(result);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _mediator.Send(
                new DeleteClientCommand(id));

            return NoContent();
        }
    }
}