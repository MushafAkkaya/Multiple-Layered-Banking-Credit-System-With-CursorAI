using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using BankCreditApp.Application.Features.IndividualCustomers.Rules;

namespace BankCreditApp.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        // Register MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        // Register AutoMapper
        services.AddAutoMapper(assembly);

        // Register FluentValidation
        services.AddValidatorsFromAssembly(assembly);

        // Register Business Rules
        services.AddScoped<IndividualCustomerBusinessRules>();
        
        // Eğer başka business rules sınıflarınız varsa onları da buraya ekleyin
        // Örnek: services.AddScoped<CorporateCustomerBusinessRules>();

        return services;
    }
} 