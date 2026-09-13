using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Contracts.Commands.CreateContract;

public class CreateContractHandler
    : IRequestHandler<CreateContractCommand, ContractReadDto>
{
    private readonly IContractRepository _repository;

    public CreateContractHandler(IContractRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContractReadDto> Handle(
        CreateContractCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.Contract;

        var contract = new Data.Models.Contract
        {
            ContractNumber = dto.ContractNumber,
            ClientId = dto.ClientId,
            ProjectId = dto.ProjectId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            TotalAmount = dto.TotalAmount,
            Currency = dto.Currency,
            Status = dto.Status,
            Description = dto.Description
        };

        var createdContract = await _repository.AddAsync(contract);

        return new ContractReadDto
        {
            Id = createdContract.Id,
            ContractNumber = createdContract.ContractNumber,

            ClientId = createdContract.ClientId,
            ClientName = createdContract.Client?.CompanyName ?? string.Empty,

            ProjectId = createdContract.ProjectId,
            ProjectName = createdContract.Project?.Name ?? string.Empty,

            StartDate = createdContract.StartDate,
            EndDate = createdContract.EndDate,
            TotalAmount = createdContract.TotalAmount,
            Currency = createdContract.Currency,
            Status = createdContract.Status,
            Description = createdContract.Description,
            CreatedDate = createdContract.CreatedDate
        };
    }
}