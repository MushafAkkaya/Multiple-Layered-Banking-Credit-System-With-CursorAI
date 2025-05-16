using FluentValidation;

namespace BankCreditApp.Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer;

public class CreateCorporateCustomerCommandValidator : AbstractValidator<CreateCorporateCustomerCommand>
{
    public CreateCorporateCustomerCommandValidator()
    {
        RuleFor(x => x.Request.CompanyName).NotEmpty().MaximumLength(250);
        RuleFor(x => x.Request.TaxNumber).NotEmpty().Length(10);
        RuleFor(x => x.Request.TaxOffice).NotEmpty().MaximumLength(250);
        RuleFor(x => x.Request.CompanyType).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Request.AuthorizedPersonName).NotEmpty().MaximumLength(250);
        RuleFor(x => x.Request.AnnualTurnover).GreaterThan(0);
        RuleFor(x => x.Request.EstablishmentDate).NotEmpty().LessThan(DateTime.Now);
        RuleFor(x => x.Request.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Request.PhoneNumber).NotEmpty().Matches(@"^\+?[1-9][0-9]{7,14}$");
        RuleFor(x => x.Request.Address).NotEmpty().MaximumLength(500);
    }
} 