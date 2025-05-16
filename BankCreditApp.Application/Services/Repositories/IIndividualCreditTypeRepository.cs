using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Application.Services.Repositories;

public interface IIndividualCreditTypeRepository : IAsyncRepository<IndividualCreditType, Guid>
{
    Task<List<IndividualCreditType>> GetActiveIndividualCreditTypesAsync(CancellationToken cancellationToken = default);
    Task<List<IndividualCreditType>> GetEligibleCreditTypesForCustomerAsync(
        decimal creditScore, 
        decimal monthlyIncome, 
        int age,
        CancellationToken cancellationToken = default);
} 