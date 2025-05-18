using FluentValidation;

namespace BankCreditApp.Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer;

public class CreateIndividualCustomerCommandValidator : AbstractValidator<CreateIndividualCustomerCommand>
{
    public CreateIndividualCustomerCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.LastName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.Password).NotEmpty().MinimumLength(6);
        RuleFor(c => c.IdentityNumber).NotEmpty().Length(11);
        RuleFor(c => c.PhoneNumber).NotEmpty().MinimumLength(10);
        RuleFor(c => c.Address).NotEmpty().MinimumLength(10);
        RuleFor(c => c.Occupation).NotEmpty();
        RuleFor(c => c.MonthlyIncome).GreaterThan(0);
        RuleFor(c => c.DateOfBirth).NotEmpty().LessThan(DateTime.Now.AddYears(-18));
    }
} 