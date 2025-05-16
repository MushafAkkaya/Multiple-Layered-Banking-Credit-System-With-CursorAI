using BankCreditApp.Core.Repositories;

namespace BankCreditApp.Domain.Entities;

public class CreditType : Entity<Guid>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public int MinTerm { get; set; } // Ay cinsinden
    public int MaxTerm { get; set; } // Ay cinsinden
    public decimal BaseInterestRate { get; set; }
    public bool IsActive { get; set; }

    // Navigation Properties
    public ICollection<CreditApplication> CreditApplications { get; set; } = new List<CreditApplication>();
} 