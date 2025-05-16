using BankCreditApp.Application.Features.IndividualCustomers.Constants;
using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Core.CrossCuttingConcerns.Exceptions.Types;

namespace BankCreditApp.Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;

    public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public async Task CustomerShouldExist(Guid id)
    {
        var result = await _individualCustomerRepository.GetAsync(c => c.Id == id);
        if (result == null) 
            throw new BusinessException(IndividualCustomerMessages.NotFound);
    }

    public async Task CustomerIdentityNumberCannotBeDuplicated(string identityNumber)
    {
        var result = await _individualCustomerRepository.AnyAsync(c => c.IdentityNumber == identityNumber);
        if (result) 
            throw new BusinessException(IndividualCustomerMessages.AlreadyExists);
    }

    public Task CustomerMonthlyIncomeShouldBeValid(decimal monthlyIncome)
    {
        if (monthlyIncome <= 0) 
            throw new BusinessException(IndividualCustomerMessages.InvalidMonthlyIncome);
        return Task.CompletedTask;
    }
} 