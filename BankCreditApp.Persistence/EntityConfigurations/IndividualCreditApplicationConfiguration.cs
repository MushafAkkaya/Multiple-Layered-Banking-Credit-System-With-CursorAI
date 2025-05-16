using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Persistence.EntityConfigurations
{
    public class IndividualCreditApplicationConfiguration : IEntityTypeConfiguration<IndividualCreditApplication>
    {
        public void Configure(EntityTypeBuilder<IndividualCreditApplication> builder)
        {
            builder.ToTable("IndividualCreditApplications");

            builder.Property(c => c.CurrentCreditScore).IsRequired().HasColumnType("decimal(5,2)");
            builder.Property(c => c.MonthlyIncome).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.HasGuarantor).IsRequired();
            builder.Property(c => c.GuarantorIdentityNumber).HasMaxLength(11);

            builder.HasOne(c => c.IndividualCustomer)
                .WithMany()
                .HasForeignKey(c => c.IndividualCustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 