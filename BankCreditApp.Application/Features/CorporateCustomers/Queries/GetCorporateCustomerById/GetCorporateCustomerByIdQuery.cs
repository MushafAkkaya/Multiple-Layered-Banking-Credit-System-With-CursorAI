using BankCreditApp.Application.Features.CorporateCustomers.Dtos.Responses;
using MediatR;

namespace BankCreditApp.Application.Features.CorporateCustomers.Queries.GetCorporateCustomerById;

public class GetCorporateCustomerByIdQuery : IRequest<GetCorporateCustomerResponse>
{
    public Guid Id { get; set; }

    public GetCorporateCustomerByIdQuery(Guid id)
    {
        Id = id;
    }
} 