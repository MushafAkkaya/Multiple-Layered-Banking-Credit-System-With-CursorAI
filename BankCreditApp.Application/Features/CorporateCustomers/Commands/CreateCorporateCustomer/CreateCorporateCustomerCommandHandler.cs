using BankCreditApp.Application.Features.CorporateCustomers.Constants;
using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Domain.Entities;
using MediatR;

namespace BankCreditApp.Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer;

public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, Guid>
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;

    public CreateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
    }

    public async Task<Guid> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
    {
        var existingCustomer = await _corporateCustomerRepository.GetAsync(
            x => x.TaxNumber == request.Request.TaxNumber,
            cancellationToken: cancellationToken);

        if (existingCustomer != null)
            throw new Exception(CorporateCustomerMessages.AlreadyExists);

        var customer = new CorporateCustomer
        {
            CompanyName = request.Request.CompanyName,
            TaxNumber = request.Request.TaxNumber,
            TaxOffice = request.Request.TaxOffice,
            CompanyType = request.Request.CompanyType,
            AuthorizedPersonName = request.Request.AuthorizedPersonName,
            AnnualTurnover = request.Request.AnnualTurnover,
            EstablishmentDate = request.Request.EstablishmentDate,
            Email = request.Request.Email,
            PhoneNumber = request.Request.PhoneNumber,
            Address = request.Request.Address,
            CustomerNumber = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(),
            IsActive = true
        };

        await _corporateCustomerRepository.AddAsync(customer, cancellationToken);
        return customer.Id;
    }
} 