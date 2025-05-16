namespace BankCreditApp.Application.Features.CreditTypes.Dtos.Requests;

public class CreateIndividualCreditTypeRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public int MinTerm { get; set; }
    public int MaxTerm { get; set; }
    public decimal BaseInterestRate { get; set; }
    public decimal MinCreditScore { get; set; }
    public decimal MinMonthlyIncome { get; set; }
    public int? MaxAge { get; set; }
    public bool RequiresGuarantor { get; set; }
} 