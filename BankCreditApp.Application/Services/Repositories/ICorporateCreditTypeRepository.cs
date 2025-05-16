using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Application.Services.Repositories;

public interface ICorporateCreditTypeRepository : IAsyncRepository<CorporateCreditType, Guid>
{
    Task<List<CorporateCreditType>> GetActiveCorporateCreditTypesAsync(CancellationToken cancellationToken = default);
    Task<List<CorporateCreditType>> GetEligibleCreditTypesForCompanyAsync(
        decimal annualTurnover, 
        int companyAgeInMonths,
        CancellationToken cancellationToken = default);
} 