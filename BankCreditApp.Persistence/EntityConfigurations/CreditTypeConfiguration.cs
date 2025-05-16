using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Persistence.EntityConfigurations
{
    public class CreditTypeConfiguration : IEntityTypeConfiguration<CreditType>
    {
        public void Configure(EntityTypeBuilder<CreditType> builder)
        {
            builder.ToTable("CreditTypes");
            
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(500);
            builder.Property(c => c.MinAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.MaxAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.MinTerm).IsRequired();
            builder.Property(c => c.MaxTerm).IsRequired();
            builder.Property(c => c.BaseInterestRate).IsRequired().HasColumnType("decimal(5,2)");
            builder.Property(c => c.IsActive).IsRequired();
        }
    }
} 