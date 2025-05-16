using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Domain.Entities;
using MediatR;

namespace BankCreditApp.Application.Features.CreditTypes.Queries.GetEligibleCreditTypes;

public class GetEligibleIndividualCreditTypesQueryHandler : IRequestHandler<GetEligibleIndividualCreditTypesQuery, List<IndividualCreditType>>
{
    private readonly IIndividualCreditTypeRepository _repository;

    public GetEligibleIndividualCreditTypesQueryHandler(IIndividualCreditTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<IndividualCreditType>> Handle(GetEligibleIndividualCreditTypesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetEligibleCreditTypesForCustomerAsync(
            request.CreditScore,
            request.MonthlyIncome,
            request.Age,
            cancellationToken);
    }
} 