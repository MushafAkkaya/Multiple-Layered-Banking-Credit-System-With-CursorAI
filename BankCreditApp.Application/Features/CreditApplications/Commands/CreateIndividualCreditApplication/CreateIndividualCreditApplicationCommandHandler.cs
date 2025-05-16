using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Domain.Entities;
using MediatR;

namespace BankCreditApp.Application.Features.CreditApplications.Commands.CreateIndividualCreditApplication;

public class CreateIndividualCreditApplicationCommandHandler : IRequestHandler<CreateIndividualCreditApplicationCommand, Guid>
{
    private readonly IIndividualCreditApplicationRepository _creditApplicationRepository;
    private readonly IIndividualCustomerRepository _customerRepository;
    private readonly IIndividualCreditTypeRepository _creditTypeRepository;

    public CreateIndividualCreditApplicationCommandHandler(
        IIndividualCreditApplicationRepository creditApplicationRepository,
        IIndividualCustomerRepository customerRepository,
        IIndividualCreditTypeRepository creditTypeRepository)
    {
        _creditApplicationRepository = creditApplicationRepository;
        _customerRepository = customerRepository;
        _creditTypeRepository = creditTypeRepository;
    }

    public async Task<Guid> Handle(CreateIndividualCreditApplicationCommand request, CancellationToken cancellationToken)
    {
        // Validate customer exists
        var customer = await _customerRepository.GetAsync(
            x => x.Id == request.Request.IndividualCustomerId,
            cancellationToken: cancellationToken);

        if (customer == null)
            throw new Exception("Customer not found");

        // Validate credit type exists and is eligible
        var creditType = await _creditTypeRepository.GetAsync(
            x => x.Id == request.Request.CreditTypeId && x.IsActive,
            cancellationToken: cancellationToken);

        if (creditType == null)
            throw new Exception("Credit type not found or not active");

        // Check if customer has active application
        var hasActiveApplication = await _creditApplicationRepository.HasActiveApplicationAsync(
            request.Request.IndividualCustomerId,
            cancellationToken);

        if (hasActiveApplication)
            throw new Exception("Customer already has an active credit application");

        var application = new IndividualCreditApplication
        {
            IndividualCustomerId = request.Request.IndividualCustomerId,
            CreditTypeId = request.Request.CreditTypeId,
            RequestedAmount = request.Request.RequestedAmount,
            RequestedTerm = request.Request.RequestedTerm,
            CurrentCreditScore = request.Request.CurrentCreditScore,
            MonthlyIncome = request.Request.MonthlyIncome,
            HasGuarantor = request.Request.HasGuarantor,
            GuarantorIdentityNumber = request.Request.GuarantorIdentityNumber,
            ApplicationStatus = "Pending",
            ApplicationDate = DateTime.UtcNow
        };

        await _creditApplicationRepository.AddAsync(application, cancellationToken);
        return application.Id;
    }
} 