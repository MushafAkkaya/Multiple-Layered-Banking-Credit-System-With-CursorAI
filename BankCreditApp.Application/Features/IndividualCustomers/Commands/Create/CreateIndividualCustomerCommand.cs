using AutoMapper;
using BankCreditApp.Application.Features.IndividualCustomers.Dtos.Requests;
using BankCreditApp.Application.Features.IndividualCustomers.Dtos.Responses;
using BankCreditApp.Application.Features.IndividualCustomers.Rules;
using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Domain.Entities;
using MediatR;

namespace BankCreditApp.Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommand : IRequest<CreateIndividualCustomerResponse>
{
    public CreateIndividualCustomerRequest Request { get; set; } = null!;

    public class CreateIndividualCustomerCommandHandler 
        : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public CreateIndividualCustomerCommandHandler(
            IIndividualCustomerRepository individualCustomerRepository,
            IMapper mapper,
            IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreateIndividualCustomerResponse> Handle(
            CreateIndividualCustomerCommand request, 
            CancellationToken cancellationToken)
        {
            await _businessRules.CustomerIdentityNumberCannotBeDuplicated(request.Request.IdentityNumber);
            await _businessRules.CustomerMonthlyIncomeShouldBeValid(request.Request.MonthlyIncome);

            var individualCustomer = _mapper.Map<IndividualCustomer>(request.Request);
            individualCustomer.CustomerNumber = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();

            await _individualCustomerRepository.AddAsync(individualCustomer);

            return _mapper.Map<CreateIndividualCustomerResponse>(individualCustomer);
        }
    }
} 