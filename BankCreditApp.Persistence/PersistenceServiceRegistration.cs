using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BankCreditApp.Persistence.Contexts;
using BankCreditApp.Persistence.Repositories;
using BankCreditApp.Application.Services.Repositories;

namespace BankCreditApp.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, string connectionString)
    {
        // DbContext Registration
        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Repository Registrations
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
        services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();

        // Credit Type Repositories
        services.AddScoped<ICreditTypeRepository, CreditTypeRepository>();
        services.AddScoped<IIndividualCreditTypeRepository, IndividualCreditTypeRepository>();
        services.AddScoped<ICorporateCreditTypeRepository, CorporateCreditTypeRepository>();

        // Credit Application Repositories
        services.AddScoped<ICreditApplicationRepository, CreditApplicationRepository>();
        services.AddScoped<IIndividualCreditApplicationRepository, IndividualCreditApplicationRepository>();
        services.AddScoped<ICorporateCreditApplicationRepository, CorporateCreditApplicationRepository>();

        return services;
    }
} 