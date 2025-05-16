using BankCreditApp.Application.Features.CreditApplications.Dtos.Requests;
using MediatR;

namespace BankCreditApp.Application.Features.CreditApplications.Commands.CreateIndividualCreditApplication;

public class CreateIndividualCreditApplicationCommand : IRequest<Guid>
{
    public CreateIndividualCreditApplicationRequest Request { get; set; } = null!;

    public CreateIndividualCreditApplicationCommand(CreateIndividualCreditApplicationRequest request)
    {
        Request = request;
    }
} 