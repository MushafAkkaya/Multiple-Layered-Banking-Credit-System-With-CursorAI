namespace BankCreditApp.Domain.Entities;

public abstract class ApplicationUser : User
{
    public virtual Customer? Customer { get; set; }
    public Guid? CustomerId { get; set; }
} 