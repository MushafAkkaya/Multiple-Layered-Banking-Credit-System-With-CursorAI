using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Application.Services.Repositories;

public interface ICreditTypeRepository : IAsyncRepository<CreditType, Guid>
{
    Task<List<CreditType>> GetActiveCreditTypesAsync(CancellationToken cancellationToken = default);
    Task<CreditType?> GetByNameAsync(string name, bool tracking = true, CancellationToken cancellationToken = default);
} 