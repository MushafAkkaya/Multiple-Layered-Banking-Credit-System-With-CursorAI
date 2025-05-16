using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;
using BankCreditApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankCreditApp.Persistence.Repositories;

public class IndividualCreditApplicationRepository : EfRepositoryBase<IndividualCreditApplication, Guid, BaseDbContext>, IIndividualCreditApplicationRepository
{
    public IndividualCreditApplicationRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<List<IndividualCreditApplication>> GetCustomerApplicationsAsync(
        Guid customerId, 
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<IndividualCreditApplication>()
            .Where(x => x.IndividualCustomerId == customerId && x.DeletedDate == null)
            .OrderByDescending(x => x.ApplicationDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> HasActiveApplicationAsync(
        Guid customerId, 
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<IndividualCreditApplication>()
            .AnyAsync(x => x.IndividualCustomerId == customerId 
                && x.ApplicationStatus == "Pending"
                && x.DeletedDate == null, 
                cancellationToken);
    }

    public async Task<decimal> GetTotalActiveCreditsAmountAsync(
        Guid customerId, 
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<IndividualCreditApplication>()
            .Where(x => x.IndividualCustomerId == customerId 
                && x.ApplicationStatus == "Approved"
                && x.DeletedDate == null)
            .SumAsync(x => x.ApprovedAmount, cancellationToken);
    }
} 