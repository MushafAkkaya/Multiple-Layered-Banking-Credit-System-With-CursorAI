using AutoMapper;
using BankCreditApp.Application.Features.IndividualCustomers.Dtos.Requests;
using BankCreditApp.Application.Features.IndividualCustomers.Dtos.Responses;
using BankCreditApp.Application.Features.IndividualCustomers.Rules;
using BankCreditApp.Application.Services.Repositories;
using MediatR;

namespace BankCreditApp.Application.Features.IndividualCustomers.Commands.Update;

public class UpdateIndividualCustomerCommand : IRequest<UpdateIndividualCustomerResponse>
{
    public UpdateIndividualCustomerRequest Request { get; set; } = null!;

    public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, UpdateIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public UpdateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<UpdateIndividualCustomerResponse> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CustomerShouldExist(request.Request.Id);

            var individualCustomer = await _individualCustomerRepository.GetAsync(x => x.Id == request.Request.Id);
            _mapper.Map(request.Request, individualCustomer);
            await _individualCustomerRepository.UpdateAsync(individualCustomer);

            return _mapper.Map<UpdateIndividualCustomerResponse>(individualCustomer);
        }
    }
} 