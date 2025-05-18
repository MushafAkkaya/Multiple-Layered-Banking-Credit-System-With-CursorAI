using BankCreditApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BankCreditApp.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<CorporateCustomer> CorporateCustomers { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) 
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseDbContext).Assembly);

        // Configure one-to-one relationship between Customer and ApplicationUser
        modelBuilder.Entity<Customer>(c =>
        {
            c.ToTable("Customers");
            c.HasDiscriminator<string>("CustomerType")
                .HasValue<IndividualCustomer>("Individual")
                .HasValue<CorporateCustomer>("Corporate");

            c.HasOne(x => x.User)
                .WithOne(u => u.Customer)
                .HasForeignKey<Customer>(x => x.UserId)
                .IsRequired();
        });

        // Configure ApplicationUser hierarchy
        modelBuilder.Entity<ApplicationUser>(au =>
        {
            au.ToTable("Users");
            au.HasDiscriminator<string>("UserType")
                .HasValue<IndividualApplicationUser>("Individual")
                .HasValue<CorporateApplicationUser>("Corporate");
        });

        // Remove any existing table mappings for derived types
        modelBuilder.Entity<IndividualCustomer>().ToTable("Customers");
        modelBuilder.Entity<CorporateCustomer>().ToTable("Customers");
        modelBuilder.Entity<IndividualApplicationUser>().ToTable("Users");
        modelBuilder.Entity<CorporateApplicationUser>().ToTable("Users");

        // Configure specific navigation properties
        modelBuilder.Entity<IndividualApplicationUser>()
            .HasOne(u => u.IndividualCustomer)
            .WithOne()
            .HasForeignKey<IndividualCustomer>(c => c.UserId);

        modelBuilder.Entity<CorporateApplicationUser>()
            .HasOne(u => u.CorporateCustomer)
            .WithOne()
            .HasForeignKey<CorporateCustomer>(c => c.UserId);
    }
} 