using BankCreditApp.Application.Features.CreditTypes.Dtos.Requests;
using MediatR;

namespace BankCreditApp.Application.Features.CreditTypes.Commands.CreateCorporateCreditType;

public class CreateCorporateCreditTypeCommand : IRequest<Guid>
{
    public CreateCorporateCreditTypeRequest Request { get; set; }

    public CreateCorporateCreditTypeCommand(CreateCorporateCreditTypeRequest request)
    {
        Request = request;
    }
} 