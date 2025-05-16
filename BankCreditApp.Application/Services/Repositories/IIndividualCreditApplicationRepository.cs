using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Application.Services.Repositories;

public interface IIndividualCreditApplicationRepository : IAsyncRepository<IndividualCreditApplication, Guid>
{
    Task<List<IndividualCreditApplication>> GetCustomerApplicationsAsync(
        Guid customerId, 
        CancellationToken cancellationToken = default);
        
    Task<bool> HasActiveApplicationAsync(
        Guid customerId, 
        CancellationToken cancellationToken = default);
        
    Task<decimal> GetTotalActiveCreditsAmountAsync(
        Guid customerId, 
        CancellationToken cancellationToken = default);
} 