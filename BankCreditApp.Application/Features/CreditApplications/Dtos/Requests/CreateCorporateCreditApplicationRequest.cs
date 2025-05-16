namespace BankCreditApp.Application.Features.CreditApplications.Dtos.Requests;

public class CreateCorporateCreditApplicationRequest
{
    public Guid CorporateCustomerId { get; set; }
    public Guid CreditTypeId { get; set; }
    public decimal RequestedAmount { get; set; }
    public int RequestedTerm { get; set; }
    public decimal CurrentAnnualTurnover { get; set; }
    public int CompanyAgeInMonths { get; set; }
    public bool HasCollateral { get; set; }
    public decimal? CollateralValue { get; set; }
} 