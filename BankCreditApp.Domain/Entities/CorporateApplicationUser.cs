namespace BankCreditApp.Domain.Entities;

public class CorporateApplicationUser : ApplicationUser
{
    public string CompanyName { get; set; } = default!;
    public CorporateCustomer? CorporateCustomer { get; set; }

    public override string GetDisplayName()
    {
        return CompanyName;
    }
} 