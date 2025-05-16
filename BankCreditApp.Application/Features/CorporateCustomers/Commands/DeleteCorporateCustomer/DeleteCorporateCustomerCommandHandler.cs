using BankCreditApp.Application.Features.CorporateCustomers.Constants;
using BankCreditApp.Application.Services.Repositories;
using MediatR;

namespace BankCreditApp.Application.Features.CorporateCustomers.Commands.DeleteCorporateCustomer;

public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, Unit>
{
    private readonly ICorporateCustomerRepository _repository;

    public DeleteCorporateCustomerCommandHandler(ICorporateCustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteCorporateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (customer == null) throw new Exception(CorporateCustomerMessages.NotFound);
        
        await _repository.DeleteAsync(customer, cancellationToken: cancellationToken);
        return Unit.Value;
    }
} 