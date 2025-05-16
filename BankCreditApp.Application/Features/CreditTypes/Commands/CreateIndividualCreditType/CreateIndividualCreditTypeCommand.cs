using BankCreditApp.Application.Features.CreditTypes.Dtos.Requests;
using MediatR;

namespace BankCreditApp.Application.Features.CreditTypes.Commands.CreateIndividualCreditType;

public class CreateIndividualCreditTypeCommand : IRequest<Guid>
{
    public CreateIndividualCreditTypeRequest Request { get; set; }

    public CreateIndividualCreditTypeCommand(CreateIndividualCreditTypeRequest request)
    {
        Request = request;
    }
} 