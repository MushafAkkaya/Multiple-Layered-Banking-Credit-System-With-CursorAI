namespace BankCreditApp.Domain.Entities.Common;

public abstract class Entity<TId>
{
    public TId Id { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
} 