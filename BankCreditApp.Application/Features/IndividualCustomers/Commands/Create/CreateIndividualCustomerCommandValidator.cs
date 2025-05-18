using FluentValidation;
using BankCreditApp.Application.Features.IndividualCustomers.Commands;

namespace BankCreditApp.Application.Features.IndividualCustomers.Commands.Create
{
    public class CreateIndividualCustomerCommandValidator : AbstractValidator<CreateIndividualCustomerCommand>
    {
        public CreateIndividualCustomerCommandValidator()
        {
            RuleFor(x => x.Request.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Request.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.Request.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Request.LastName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Request.IdentityNumber).NotEmpty().Length(11);
            RuleFor(x => x.Request.PhoneNumber).NotEmpty().MinimumLength(10);
            RuleFor(x => x.Request.Address).NotEmpty().MinimumLength(10);
            RuleFor(x => x.Request.Occupation).NotEmpty();
            RuleFor(x => x.Request.MonthlyIncome).GreaterThan(0);
            RuleFor(x => x.Request.DateOfBirth).NotEmpty().LessThan(DateTime.Now.AddYears(-18));
        }
    }
} 