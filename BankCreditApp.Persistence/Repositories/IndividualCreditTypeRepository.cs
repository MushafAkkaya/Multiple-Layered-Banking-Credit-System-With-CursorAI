using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;
using BankCreditApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankCreditApp.Persistence.Repositories;

public class IndividualCreditTypeRepository : EfRepositoryBase<IndividualCreditType, Guid, BaseDbContext>, IIndividualCreditTypeRepository
{
    public IndividualCreditTypeRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<List<IndividualCreditType>> GetActiveIndividualCreditTypesAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Set<IndividualCreditType>()
            .Where(x => x.IsActive && x.DeletedDate == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<IndividualCreditType>> GetEligibleCreditTypesForCustomerAsync(
        decimal creditScore, 
        decimal monthlyIncome, 
        int age,
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<IndividualCreditType>()
            .Where(x => x.IsActive 
                && x.DeletedDate == null
                && x.MinCreditScore <= creditScore
                && x.MinMonthlyIncome <= monthlyIncome
                && (!x.MaxAge.HasValue || x.MaxAge >= age))
            .ToListAsync(cancellationToken);
    }
} 