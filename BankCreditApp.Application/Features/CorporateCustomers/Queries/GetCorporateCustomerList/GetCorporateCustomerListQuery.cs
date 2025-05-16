using BankCreditApp.Application.Features.CorporateCustomers.Dtos.Responses;
using BankCreditApp.Core.Repositories;
using MediatR;

namespace BankCreditApp.Application.Features.CorporateCustomers.Queries.GetCorporateCustomerList;

public class GetCorporateCustomerListQuery : IRequest<PaginatedList<GetCorporateCustomerResponse>>
{
    public PaginationParams PaginationParams { get; set; }

    public GetCorporateCustomerListQuery(PaginationParams paginationParams)
    {
        PaginationParams = paginationParams;
    }
} 