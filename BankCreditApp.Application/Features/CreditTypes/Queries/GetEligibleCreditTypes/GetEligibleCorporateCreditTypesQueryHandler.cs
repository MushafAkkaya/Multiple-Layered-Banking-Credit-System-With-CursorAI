using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Domain.Entities;
using MediatR;

namespace BankCreditApp.Application.Features.CreditTypes.Queries.GetEligibleCreditTypes;

public class GetEligibleCorporateCreditTypesQueryHandler : IRequestHandler<GetEligibleCorporateCreditTypesQuery, List<CorporateCreditType>>
{
    private readonly ICorporateCreditTypeRepository _repository;

    public GetEligibleCorporateCreditTypesQueryHandler(ICorporateCreditTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CorporateCreditType>> Handle(GetEligibleCorporateCreditTypesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetEligibleCreditTypesForCompanyAsync(
            request.AnnualTurnover,
            request.CompanyAgeInMonths,
            cancellationToken);
    }
} 