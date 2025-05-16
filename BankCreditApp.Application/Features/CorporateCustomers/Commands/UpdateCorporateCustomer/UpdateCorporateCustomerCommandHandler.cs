using BankCreditApp.Application.Features.CorporateCustomers.Constants;
using BankCreditApp.Application.Services.Repositories;
using MediatR;

namespace BankCreditApp.Application.Features.CorporateCustomers.Commands.UpdateCorporateCustomer;

public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, Unit>
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;

    public UpdateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
    }

    public async Task<Unit> Handle(UpdateCorporateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _corporateCustomerRepository.GetAsync(
            x => x.Id == request.Request.Id,
            cancellationToken: cancellationToken);

        if (customer == null)
            throw new Exception(CorporateCustomerMessages.NotFound);

        customer.CompanyName = request.Request.CompanyName;
        customer.AuthorizedPersonName = request.Request.AuthorizedPersonName;
        customer.AnnualTurnover = request.Request.AnnualTurnover;
        customer.Email = request.Request.Email;
        customer.PhoneNumber = request.Request.PhoneNumber;
        customer.Address = request.Request.Address;

        await _corporateCustomerRepository.UpdateAsync(customer, cancellationToken);
        return Unit.Value;
    }
} 