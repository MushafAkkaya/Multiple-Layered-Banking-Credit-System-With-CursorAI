using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;
using BankCreditApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankCreditApp.Persistence.Repositories;

public class CreditTypeRepository : EfRepositoryBase<CreditType, Guid, BaseDbContext>, ICreditTypeRepository
{
    public CreditTypeRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<List<CreditType>> GetActiveCreditTypesAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Set<CreditType>()
            .Where(x => x.IsActive && x.DeletedDate == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<CreditType?> GetByNameAsync(string name, bool tracking = true, CancellationToken cancellationToken = default)
    {
        var query = Context.Set<CreditType>().AsQueryable();
        
        if (!tracking)
            query = query.AsNoTracking();
            
        return await query
            .FirstOrDefaultAsync(x => x.Name == name && x.DeletedDate == null, cancellationToken);
    }
} 