using BankCreditApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankCreditApp.Persistence.EntityConfigurations
{
    public class CorporateCreditApplicationConfiguration : IEntityTypeConfiguration<CorporateCreditApplication>
    {
        public void Configure(EntityTypeBuilder<CorporateCreditApplication> builder)
        {
            builder.ToTable("CorporateCreditApplications");

            builder.Property(c => c.CurrentAnnualTurnover).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.CompanyAgeInMonths).IsRequired();
            builder.Property(c => c.HasCollateral).IsRequired();
            builder.Property(c => c.CollateralValue).HasColumnType("decimal(18,2)");

            builder.HasOne(c => c.CorporateCustomer)
                .WithMany()
                .HasForeignKey(c => c.CorporateCustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 