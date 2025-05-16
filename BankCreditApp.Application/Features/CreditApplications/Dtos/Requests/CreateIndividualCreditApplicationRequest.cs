namespace BankCreditApp.Application.Features.CreditApplications.Dtos.Requests;

public class CreateIndividualCreditApplicationRequest
{
    public Guid IndividualCustomerId { get; set; }
    public Guid CreditTypeId { get; set; }
    public decimal RequestedAmount { get; set; }
    public int RequestedTerm { get; set; }
    public decimal CurrentCreditScore { get; set; }
    public decimal MonthlyIncome { get; set; }
    public bool HasGuarantor { get; set; }
    public string? GuarantorIdentityNumber { get; set; }
} 