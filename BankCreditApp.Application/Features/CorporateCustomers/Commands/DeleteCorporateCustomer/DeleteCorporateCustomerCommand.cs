using MediatR;

namespace BankCreditApp.Application.Features.CorporateCustomers.Commands.DeleteCorporateCustomer;

public class DeleteCorporateCustomerCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeleteCorporateCustomerCommand(Guid id)
    {
        Id = id;
    }
} 