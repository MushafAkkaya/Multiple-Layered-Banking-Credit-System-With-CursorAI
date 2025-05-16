using BankCreditApp.Domain.Entities;
using MediatR;

namespace BankCreditApp.Application.Features.CreditTypes.Queries.GetEligibleCreditTypes;

public class GetEligibleIndividualCreditTypesQuery : IRequest<List<IndividualCreditType>>
{
    public decimal CreditScore { get; set; }
    public decimal MonthlyIncome { get; set; }
    public int Age { get; set; }

    public GetEligibleIndividualCreditTypesQuery(decimal creditScore, decimal monthlyIncome, int age)
    {
        CreditScore = creditScore;
        MonthlyIncome = monthlyIncome;
        Age = age;
    }
} 