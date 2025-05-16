using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Application.Services.Repositories;

public interface ICreditApplicationRepository : IAsyncRepository<CreditApplication, Guid>
{
    Task<List<CreditApplication>> GetPendingApplicationsAsync(CancellationToken cancellationToken = default);
    Task<int> GetTotalApplicationCountByStatusAsync(string status, CancellationToken cancellationToken = default);
    Task<decimal> GetTotalApprovedAmountAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
} 