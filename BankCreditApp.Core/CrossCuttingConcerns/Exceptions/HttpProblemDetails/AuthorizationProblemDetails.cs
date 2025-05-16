using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankCreditApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class AuthorizationProblemDetails : ProblemDetails
{
    public AuthorizationProblemDetails()
    {
        Title = "Authorization error";
        Detail = "You are not authorized to access this resource.";
        Status = StatusCodes.Status401Unauthorized;
        Type = "https://example.com/probs/authorization";
    }
} 