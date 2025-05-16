using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Application.Services.Repositories;

public interface IIndividualCustomerRepository : IAsyncRepository<IndividualCustomer, Guid>
{
} 