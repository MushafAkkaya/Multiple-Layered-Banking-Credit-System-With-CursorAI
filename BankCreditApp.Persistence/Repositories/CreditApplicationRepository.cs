using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;
using BankCreditApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankCreditApp.Persistence.Repositories;

public class CreditApplicationRepository : EfRepositoryBase<CreditApplication, Guid, BaseDbContext>, ICreditApplicationRepository
{
    public CreditApplicationRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<List<CreditApplication>> GetPendingApplicationsAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Set<CreditApplication>()
            .Where(x => x.ApplicationStatus == "Pending" && x.DeletedDate == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetTotalApplicationCountByStatusAsync(string status, CancellationToken cancellationToken = default)
    {
        return await Context.Set<CreditApplication>()
            .CountAsync(x => x.ApplicationStatus == status && x.DeletedDate == null, cancellationToken);
    }

    public async Task<decimal> GetTotalApprovedAmountAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        return await Context.Set<CreditApplication>()
            .Where(x => x.ApplicationStatus == "Approved" 
                && x.ApprovalDate >= startDate 
                && x.ApprovalDate <= endDate
                && x.DeletedDate == null)
            .SumAsync(x => x.ApprovedAmount, cancellationToken);
    }
} 