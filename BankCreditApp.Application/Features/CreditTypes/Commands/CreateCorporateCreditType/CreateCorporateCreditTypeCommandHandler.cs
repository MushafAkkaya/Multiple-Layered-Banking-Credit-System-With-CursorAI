using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Domain.Entities;
using MediatR;

namespace BankCreditApp.Application.Features.CreditTypes.Commands.CreateCorporateCreditType;

public class CreateCorporateCreditTypeCommandHandler : IRequestHandler<CreateCorporateCreditTypeCommand, Guid>
{
    private readonly ICorporateCreditTypeRepository _repository;

    public CreateCorporateCreditTypeCommandHandler(ICorporateCreditTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateCorporateCreditTypeCommand request, CancellationToken cancellationToken)
    {
        var creditType = new CorporateCreditType
        {
            Name = request.Request.Name,
            Description = request.Request.Description,
            MinAmount = request.Request.MinAmount,
            MaxAmount = request.Request.MaxAmount,
            MinTerm = request.Request.MinTerm,
            MaxTerm = request.Request.MaxTerm,
            BaseInterestRate = request.Request.BaseInterestRate,
            MinAnnualTurnover = request.Request.MinAnnualTurnover,
            MinCompanyAge = request.Request.MinCompanyAge,
            RequiresCollateral = request.Request.RequiresCollateral,
            IsActive = true
        };

        await _repository.AddAsync(creditType, cancellationToken);
        return creditType.Id;
    }
} 