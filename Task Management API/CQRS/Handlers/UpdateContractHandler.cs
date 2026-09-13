using MediatR;
using Task_Management_API.CQRS.Commands;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Repository;

namespace Task_Management_API.Features.Contracts.Commands.UpdateContract;

public class UpdateContractHandler
    : IRequestHandler<UpdateContractCommand, ContractReadDto?>
{
    private readonly IContractRepository _repository;

    public UpdateContractHandler(IContractRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContractReadDto?> Handle(
        UpdateContractCommand request,
        CancellationToken cancellationToken)
    {
        var contract = await _repository.GetByIdAsync(request.Id);

        if (contract == null)
            return null;

        var dto = request.Contract;

        contract.ContractNumber = dto.ContractNumber;
        contract.ClientId = dto.ClientId;
        contract.ProjectId = dto.ProjectId;
        contract.StartDate = dto.StartDate;
        contract.EndDate = dto.EndDate;
        contract.TotalAmount = dto.TotalAmount;
        contract.Currency = dto.Currency;
        contract.Status = dto.Status;
        contract.Description = dto.Description;

        await _repository.UpdateAsync(contract);

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