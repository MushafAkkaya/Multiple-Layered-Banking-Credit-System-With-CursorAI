namespace BankCreditApp.Domain.Entities;

public abstract class Customer : Core.Repositories.Entity<Guid>
{
    public string CustomerNumber { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
    public bool IsActive { get; set; } = true;
    
    public virtual ApplicationUser User { get; set; } = default!;
    public Guid UserId { get; set; }
} 