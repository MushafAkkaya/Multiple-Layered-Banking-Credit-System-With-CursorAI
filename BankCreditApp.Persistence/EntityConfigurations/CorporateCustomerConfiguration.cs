using BankCreditApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankCreditApp.Persistence.EntityConfigurations;

public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
{
    public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
    {
        builder.ToTable("CorporateCustomers");

        builder.Property(c => c.CompanyName).IsRequired().HasMaxLength(250);
        builder.Property(c => c.TaxNumber).IsRequired().HasMaxLength(10);
        builder.Property(c => c.TaxOffice).IsRequired().HasMaxLength(250);
        builder.Property(c => c.CompanyType).IsRequired().HasMaxLength(50);
        builder.Property(c => c.AuthorizedPersonName).IsRequired().HasMaxLength(250);
        builder.Property(c => c.AnnualTurnover).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(c => c.EstablishmentDate).IsRequired();
    }
} 