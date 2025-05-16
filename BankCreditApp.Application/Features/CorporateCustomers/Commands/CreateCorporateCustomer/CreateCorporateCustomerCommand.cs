using BankCreditApp.Application.Features.CorporateCustomers.Dtos.Requests;
using MediatR;

namespace BankCreditApp.Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer;

public class CreateCorporateCustomerCommand : IRequest<Guid>
{
    public CreateCorporateCustomerRequest Request { get; set; }

    public CreateCorporateCustomerCommand(CreateCorporateCustomerRequest request)
    {
        Request = request;
    }
} 