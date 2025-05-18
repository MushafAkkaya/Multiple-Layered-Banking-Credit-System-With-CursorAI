using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var userRoles = _httpContextAccessor.HttpContext.User.ClaimRoles();

        if (userRoles == null) throw new UnauthorizedAccessException("Claims not found.");

        bool isRoleMatch = false;
        foreach (var role in request.Roles)
        {
            if (userRoles.Contains(role))
            {
                isRoleMatch = true;
                break;
            }
        }

        if (!isRoleMatch) throw new UnauthorizedAccessException("You are not authorized.");

        var response = await next();
        return response;
    }
} 