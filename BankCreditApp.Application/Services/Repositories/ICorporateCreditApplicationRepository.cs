using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Application.Services.Repositories;

public interface ICorporateCreditApplicationRepository : IAsyncRepository<CorporateCreditApplication, Guid>
{
    Task<List<CorporateCreditApplication>> GetCompanyApplicationsAsync(
        Guid customerId, 
        CancellationToken cancellationToken = default);
        
    Task<bool> HasActiveApplicationAsync(
        Guid customerId, 
        CancellationToken cancellationToken = default);
        
    Task<decimal> GetTotalActiveCreditsAmountAsync(
        Guid customerId, 
        CancellationToken cancellationToken = default);
} 