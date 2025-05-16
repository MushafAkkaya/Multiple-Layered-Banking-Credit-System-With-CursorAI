using BankCreditApp.Application.Features.CreditApplications.Dtos.Responses;
using BankCreditApp.Core.Repositories;
using MediatR;

namespace BankCreditApp.Application.Features.CreditApplications.Queries.GetCustomerCreditApplications;

public class GetCustomerCreditApplicationsQuery : IRequest<PaginatedCreditApplicationListResponse>
{
    public Guid CustomerId { get; set; }
    public bool IsIndividual { get; set; }
    public PaginationParams PaginationParams { get; set; }

    public GetCustomerCreditApplicationsQuery(Guid customerId, bool isIndividual, PaginationParams paginationParams)
    {
        CustomerId = customerId;
        IsIndividual = isIndividual;
        PaginationParams = paginationParams;
    }
} 