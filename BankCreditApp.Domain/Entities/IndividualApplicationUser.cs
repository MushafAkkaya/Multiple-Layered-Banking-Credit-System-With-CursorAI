namespace BankCreditApp.Domain.Entities;

public class IndividualApplicationUser : ApplicationUser
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public IndividualCustomer? IndividualCustomer { get; set; }

    public override string GetDisplayName()
    {
        return $"{FirstName} {LastName}";
    }
} 