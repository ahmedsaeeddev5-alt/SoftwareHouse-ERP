using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;

namespace Task_Management_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContractsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContractsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Contracts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContractReadDto>>> GetContracts()
    {
        var contracts = await _mediator.Send(new GetContractsQuery());

        return Ok(contracts);
    }

    // GET: api/Contracts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ContractReadDto>> GetContractById(int id)
    {
        var contract = await _mediator.Send(
            new GetContractByIdQuery(id));

        if (contract == null)
            return NotFound(new
            {
                message = "Contract not found."
            });

        return Ok(contract);
    }

    [HttpPost]
    public async Task<ActionResult<ContractReadDto>> CreateContract(
    [FromBody] ContractCreateDto dto)
    {
        var contract = await _mediator.Send(
            new CreateContractCommand(dto));

        return CreatedAtAction(
            nameof(GetContractById),
            new { id = contract.Id },
            contract);
    }

    // PUT: api/Contracts/5
    [HttpPut("{id}")]
    public async Task<ActionResult<ContractReadDto>> UpdateContract(
        int id,
        ContractCreateDto dto)
    {
        var contract = await _mediator.Send(
            new UpdateContractCommand(id, dto));

        if (contract == null)
            return NotFound(new
            {
                message = "Contract not found."
            });

        return Ok(contract);
    }

    // DELETE: api/Contracts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContract(int id)
    {
        var result = await _mediator.Send(
            new DeleteContractCommand(id));

        if (!result)
            return NotFound(new
            {
                message = "Contract not found."
            });

        return NoContent();
    }
}