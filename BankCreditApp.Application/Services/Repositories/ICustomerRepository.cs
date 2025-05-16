using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Application.Services.Repositories;

public interface ICustomerRepository : IAsyncRepository<Customer, Guid>
{
} 