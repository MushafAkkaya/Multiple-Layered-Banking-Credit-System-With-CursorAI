using BankCreditApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankCreditApp.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.CustomerNumber).IsRequired();
        builder.Property(c => c.PhoneNumber).IsRequired();
        builder.Property(c => c.Email).IsRequired();
        builder.Property(c => c.Address).IsRequired();
        
        // TPT stratejisi için discriminator kaldırılıyor
    }
} 