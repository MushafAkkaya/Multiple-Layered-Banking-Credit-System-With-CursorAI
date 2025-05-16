using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Persistence.EntityConfigurations
{
    public class CreditApplicationConfiguration : IEntityTypeConfiguration<CreditApplication>
    {
        public void Configure(EntityTypeBuilder<CreditApplication> builder)
        {
            builder.ToTable("CreditApplications");

            builder.Property(c => c.RequestedAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.RequestedTerm).IsRequired();
            builder.Property(c => c.ApprovedAmount).HasColumnType("decimal(18,2)");
            builder.Property(c => c.AssignedInterestRate).HasColumnType("decimal(5,2)");
            builder.Property(c => c.ApplicationStatus).IsRequired().HasMaxLength(20);
            builder.Property(c => c.RejectionReason).HasMaxLength(500);
            builder.Property(c => c.ApplicationDate).IsRequired();

            builder.HasOne(c => c.CreditType)
                .WithMany(ct => ct.CreditApplications)
                .HasForeignKey(c => c.CreditTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 