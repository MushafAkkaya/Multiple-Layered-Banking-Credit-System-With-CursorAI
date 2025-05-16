using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Persistence.EntityConfigurations
{
    public class CorporateCreditTypeConfiguration : IEntityTypeConfiguration<CorporateCreditType>
    {
        public void Configure(EntityTypeBuilder<CorporateCreditType> builder)
        {
            builder.ToTable("CorporateCreditTypes");

            builder.Property(c => c.MinAnnualTurnover).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.MinCompanyAge).IsRequired();
            builder.Property(c => c.RequiresCollateral).IsRequired();
        }
    }
} 