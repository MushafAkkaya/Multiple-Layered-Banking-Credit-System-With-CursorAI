using BankCreditApp.Application.Services.Repositories;
using MediatR;

namespace BankCreditApp.Application.Features.CreditTypes.Commands.UpdateCreditTypeStatus;

public class UpdateCreditTypeStatusCommandHandler : IRequestHandler<UpdateCreditTypeStatusCommand, Unit>
{
    private readonly ICreditTypeRepository _repository;

    public UpdateCreditTypeStatusCommandHandler(ICreditTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateCreditTypeStatusCommand request, CancellationToken cancellationToken)
    {
        var creditType = await _repository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (creditType == null) throw new Exception("Credit type not found");

        creditType.IsActive = request.IsActive;
        await _repository.UpdateAsync(creditType, cancellationToken);
        return Unit.Value;
    }
} 