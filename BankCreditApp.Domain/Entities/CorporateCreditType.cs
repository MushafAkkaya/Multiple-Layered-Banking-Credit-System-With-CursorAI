namespace BankCreditApp.Domain.Entities;

public class CorporateCreditType : CreditType
{
    public decimal MinAnnualTurnover { get; set; }
    public int MinCompanyAge { get; set; } // Ay cinsinden
    public bool RequiresCollateral { get; set; }
} 