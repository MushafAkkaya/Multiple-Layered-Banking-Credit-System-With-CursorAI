using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;
using BankCreditApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankCreditApp.Persistence.Repositories;

public class CorporateCreditTypeRepository : EfRepositoryBase<CorporateCreditType, Guid, BaseDbContext>, ICorporateCreditTypeRepository
{
    public CorporateCreditTypeRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<List<CorporateCreditType>> GetActiveCorporateCreditTypesAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Set<CorporateCreditType>()
            .Where(x => x.IsActive && x.DeletedDate == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<CorporateCreditType>> GetEligibleCreditTypesForCompanyAsync(
        decimal annualTurnover, 
        int companyAgeInMonths,
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<CorporateCreditType>()
            .Where(x => x.IsActive 
                && x.DeletedDate == null
                && x.MinAnnualTurnover <= annualTurnover
                && x.MinCompanyAge <= companyAgeInMonths)
            .ToListAsync(cancellationToken);
    }
} 