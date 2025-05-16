namespace BankCreditApp.Domain.Entities;

public class IndividualCreditApplication : CreditApplication
{
    public Guid IndividualCustomerId { get; set; }
    public decimal CurrentCreditScore { get; set; }
    public decimal MonthlyIncome { get; set; }
    public bool HasGuarantor { get; set; }
    public string? GuarantorIdentityNumber { get; set; }

    // Navigation Properties
    public IndividualCustomer IndividualCustomer { get; set; } = default!;
} 