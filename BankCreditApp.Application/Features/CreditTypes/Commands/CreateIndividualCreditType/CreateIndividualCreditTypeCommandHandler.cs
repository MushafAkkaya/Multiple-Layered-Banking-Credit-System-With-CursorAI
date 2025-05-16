using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Domain.Entities;
using MediatR;

namespace BankCreditApp.Application.Features.CreditTypes.Commands.CreateIndividualCreditType;

public class CreateIndividualCreditTypeCommandHandler : IRequestHandler<CreateIndividualCreditTypeCommand, Guid>
{
    private readonly IIndividualCreditTypeRepository _repository;

    public CreateIndividualCreditTypeCommandHandler(IIndividualCreditTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateIndividualCreditTypeCommand request, CancellationToken cancellationToken)
    {
        var creditType = new IndividualCreditType
        {
            Name = request.Request.Name,
            Description = request.Request.Description,
            MinAmount = request.Request.MinAmount,
            MaxAmount = request.Request.MaxAmount,
            MinTerm = request.Request.MinTerm,
            MaxTerm = request.Request.MaxTerm,
            BaseInterestRate = request.Request.BaseInterestRate,
            MinCreditScore = request.Request.MinCreditScore,
            MinMonthlyIncome = request.Request.MinMonthlyIncome,
            MaxAge = request.Request.MaxAge,
            RequiresGuarantor = request.Request.RequiresGuarantor,
            IsActive = true
        };

        await _repository.AddAsync(creditType, cancellationToken);
        return creditType.Id;
    }
} 