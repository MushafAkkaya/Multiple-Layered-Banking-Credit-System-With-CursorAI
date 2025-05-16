using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;
using BankCreditApp.Persistence.Contexts;

namespace BankCreditApp.Persistence.Repositories;

public class CorporateCustomerRepository : EfRepositoryBase<CorporateCustomer, Guid, BaseDbContext>, ICorporateCustomerRepository
{
    public CorporateCustomerRepository(BaseDbContext context) : base(context)
    {
    }
} 