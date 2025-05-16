namespace BankCreditApp.Domain.Entities;

public class CorporateCreditApplication : CreditApplication
{
    public Guid CorporateCustomerId { get; set; }
    public decimal CurrentAnnualTurnover { get; set; }
    public int CompanyAgeInMonths { get; set; }
    public bool HasCollateral { get; set; }
    public decimal? CollateralValue { get; set; }

    // Navigation Properties
    public CorporateCustomer CorporateCustomer { get; set; } = default!;
} 