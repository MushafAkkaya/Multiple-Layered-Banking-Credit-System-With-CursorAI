using BankCreditApp.Domain.Entities;
using MediatR;

namespace BankCreditApp.Application.Features.CreditTypes.Queries.GetEligibleCreditTypes;

public class GetEligibleCorporateCreditTypesQuery : IRequest<List<CorporateCreditType>>
{
    public decimal AnnualTurnover { get; set; }
    public int CompanyAgeInMonths { get; set; }

    public GetEligibleCorporateCreditTypesQuery(decimal annualTurnover, int companyAgeInMonths)
    {
        AnnualTurnover = annualTurnover;
        CompanyAgeInMonths = companyAgeInMonths;
    }
} 