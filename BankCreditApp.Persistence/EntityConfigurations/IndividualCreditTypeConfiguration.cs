using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Persistence.EntityConfigurations
{
    public class IndividualCreditTypeConfiguration : IEntityTypeConfiguration<IndividualCreditType>
    {
        public void Configure(EntityTypeBuilder<IndividualCreditType> builder)
        {
            builder.ToTable("IndividualCreditTypes");

            builder.Property(c => c.MinCreditScore).IsRequired().HasColumnType("decimal(5,2)");
            builder.Property(c => c.MinMonthlyIncome).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.RequiresGuarantor).IsRequired();
        }
    }
} 