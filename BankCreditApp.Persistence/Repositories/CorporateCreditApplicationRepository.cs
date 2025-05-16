using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;
using BankCreditApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankCreditApp.Persistence.Repositories;

public class CorporateCreditApplicationRepository : EfRepositoryBase<CorporateCreditApplication, Guid, BaseDbContext>, ICorporateCreditApplicationRepository
{
    public CorporateCreditApplicationRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<List<CorporateCreditApplication>> GetCompanyApplicationsAsync(
        Guid customerId, 
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Where(x => x.CorporateCustomerId == customerId && x.DeletedDate == null)
            .OrderByDescending(x => x.ApplicationDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> HasActiveApplicationAsync(
        Guid customerId, 
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<CorporateCreditApplication>()
            .AnyAsync(x => x.CorporateCustomerId == customerId 
                && x.ApplicationStatus == "Pending"
                && x.DeletedDate == null, 
                cancellationToken);
    }

    public async Task<decimal> GetTotalActiveCreditsAmountAsync(
        Guid customerId, 
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Where(x => x.CorporateCustomerId == customerId 
                && x.ApplicationStatus == "Approved"
                && x.DeletedDate == null)
            .SumAsync(x => x.ApprovedAmount, cancellationToken);
    }
} 