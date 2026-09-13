using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Contracts.Queries.GetContracts;

public class GetContractsHandler
    : IRequestHandler<GetContractsQuery, IEnumerable<ContractReadDto>>
{
    private readonly IContractRepository _repository;

    public GetContractsHandler(IContractRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ContractReadDto>> Handle(
        GetContractsQuery request,
        CancellationToken cancellationToken)
    {
        var contracts = await _repository.GetAllAsync();

        return contracts.Select(c => new ContractReadDto
        {
            Id = c.Id,
            ContractNumber = c.ContractNumber,

            ClientId = c.ClientId,
            ClientName = c.Client?.CompanyName ?? string.Empty,

            ProjectId = c.ProjectId,
            ProjectName = c.Project?.Name ?? string.Empty,

            StartDate = c.StartDate,
            EndDate = c.EndDate,
            TotalAmount = c.TotalAmount,
            Currency = c.Currency,
            Status = c.Status,
            Description = c.Description,
            CreatedDate = c.CreatedDate
        });
    }
}