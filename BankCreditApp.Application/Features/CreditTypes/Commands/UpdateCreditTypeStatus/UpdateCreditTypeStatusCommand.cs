using MediatR;

namespace BankCreditApp.Application.Features.CreditTypes.Commands.UpdateCreditTypeStatus;

public class UpdateCreditTypeStatusCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }

    public UpdateCreditTypeStatusCommand(Guid id, bool isActive)
    {
        Id = id;
        IsActive = isActive;
    }
} 