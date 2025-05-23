using BankCreditApp.Core.CrossCuttingConcerns.Exceptions.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace BankCreditApp.Core.CrossCuttingConcerns.Exceptions.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
} 