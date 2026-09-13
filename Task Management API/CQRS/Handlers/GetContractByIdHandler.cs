using MediatR;
using Task_Management_API.CQRS.Queries;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Contracts.Queries.GetContractById;

public class GetContractByIdHandler
    : IRequestHandler<GetContractByIdQuery, ContractReadDto?>
{
    private readonly IContractRepository _repository;

    public GetContractByIdHandler(IContractRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContractReadDto?> Handle(
        GetContractByIdQuery request,
        CancellationToken cancellationToken)
    {
        var contract = await _repository.GetByIdAsync(request.Id);

        if (contract == null)
            return null;

        return new ContractReadDto
        {
            Id = contract.Id,
            ContractNumber = contract.ContractNumber,

            ClientId = contract.ClientId,
            ClientName = contract.Client?.CompanyName ?? string.Empty,

            ProjectId = contract.ProjectId,
            ProjectName = contract.Project?.Name ?? string.Empty,

            StartDate = contract.StartDate,
            EndDate = contract.EndDate,
            TotalAmount = contract.TotalAmount,
            Currency = contract.Currency,
            Status = contract.Status,
            Description = contract.Description,
            CreatedDate = contract.CreatedDate
        };
    }
}