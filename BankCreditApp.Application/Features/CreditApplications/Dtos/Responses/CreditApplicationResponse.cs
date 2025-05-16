namespace BankCreditApp.Application.Features.CreditApplications.Dtos.Responses;

public class CreditApplicationResponse
{
    public Guid Id { get; set; }
    public Guid CreditTypeId { get; set; }
    public string CreditTypeName { get; set; } = null!;
    public decimal RequestedAmount { get; set; }
    public int RequestedTerm { get; set; }
    public decimal? ApprovedAmount { get; set; }
    public int? ApprovedTerm { get; set; }
    public decimal? AssignedInterestRate { get; set; }
    public string ApplicationStatus { get; set; } = null!;
    public string? RejectionReason { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
} 