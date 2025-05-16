namespace BankCreditApp.Application.Features.CreditTypes.Dtos.Requests;

public class CreateCorporateCreditTypeRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public int MinTerm { get; set; }
    public int MaxTerm { get; set; }
    public decimal BaseInterestRate { get; set; }
    public decimal MinAnnualTurnover { get; set; }
    public int MinCompanyAge { get; set; }
    public bool RequiresCollateral { get; set; }
} 