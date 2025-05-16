using BankCreditApp.Application.Features.CorporateCustomers.Dtos.Requests;
using MediatR;

namespace BankCreditApp.Application.Features.CorporateCustomers.Commands.UpdateCorporateCustomer;

public class UpdateCorporateCustomerCommand : IRequest<Unit>
{
    public UpdateCorporateCustomerRequest Request { get; set; }

    public UpdateCorporateCustomerCommand(UpdateCorporateCustomerRequest request)
    {
        Request = request;
    }
} 