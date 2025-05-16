using BankCreditApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankCreditApp.Persistence.EntityConfigurations;

public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
    {
        builder.ToTable("IndividualCustomers");

        builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
        builder.Property(c => c.IdentityNumber).IsRequired().HasMaxLength(11);
        builder.Property(c => c.Occupation).IsRequired().HasMaxLength(250);
        builder.Property(c => c.MonthlyIncome).IsRequired().HasColumnType("decimal(18,2)");
    }
} 