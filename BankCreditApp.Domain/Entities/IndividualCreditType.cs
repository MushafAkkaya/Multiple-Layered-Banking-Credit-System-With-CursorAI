namespace BankCreditApp.Domain.Entities;

public class IndividualCreditType : CreditType
{
    public decimal MinCreditScore { get; set; }
    public decimal MinMonthlyIncome { get; set; }
    public int? MaxAge { get; set; }
    public bool RequiresGuarantor { get; set; }
} 