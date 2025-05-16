using BankCreditApp.Core.Repositories;  // Change this import
namespace BankCreditApp.Domain.Entities;

public class CreditApplication : Entity<Guid>
{
    public Guid CreditTypeId { get; set; }
    public decimal RequestedAmount { get; set; }
    public int RequestedTerm { get; set; } // Ay cinsinden
    public decimal ApprovedAmount { get; set; }
    public int? ApprovedTerm { get; set; }
    public decimal? AssignedInterestRate { get; set; }
    public string ApplicationStatus { get; set; } = default!; // Pending, Approved, Rejected
    public string? RejectionReason { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? ApprovalDate { get; set; }

    // Navigation Properties
    public CreditType CreditType { get; set; } = default!;
} 