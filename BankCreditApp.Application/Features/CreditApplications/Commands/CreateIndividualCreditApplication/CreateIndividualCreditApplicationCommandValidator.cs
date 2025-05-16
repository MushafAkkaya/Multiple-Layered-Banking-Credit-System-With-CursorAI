using FluentValidation;

namespace BankCreditApp.Application.Features.CreditApplications.Commands.CreateIndividualCreditApplication;

public class CreateIndividualCreditApplicationCommandValidator : AbstractValidator<CreateIndividualCreditApplicationCommand>
{
    public CreateIndividualCreditApplicationCommandValidator()
    {
        RuleFor(x => x.Request.IndividualCustomerId).NotEmpty();
        RuleFor(x => x.Request.CreditTypeId).NotEmpty();
        RuleFor(x => x.Request.RequestedAmount).GreaterThan(0);
        RuleFor(x => x.Request.RequestedTerm).GreaterThan(0);
        RuleFor(x => x.Request.CurrentCreditScore).InclusiveBetween(0, 1900);
        RuleFor(x => x.Request.MonthlyIncome).GreaterThan(0);
        RuleFor(x => x.Request.GuarantorIdentityNumber)
            .Length(11)
            .When(x => x.Request.HasGuarantor);
    }
} 