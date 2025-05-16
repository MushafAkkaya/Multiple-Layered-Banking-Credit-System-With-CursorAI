using AutoMapper;
using BankCreditApp.Application.Features.IndividualCustomers.Dtos.Responses;
using BankCreditApp.Application.Features.IndividualCustomers.Rules;
using BankCreditApp.Application.Services.Repositories;
using MediatR;

namespace BankCreditApp.Application.Features.IndividualCustomers.Queries.GetById;

public class GetByIdIndividualCustomerQuery : IRequest<GetIndividualCustomerResponse>
{
    public Guid Id { get; set; }

    public class GetByIdIndividualCustomerQueryHandler 
        : IRequestHandler<GetByIdIndividualCustomerQuery, GetIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public GetByIdIndividualCustomerQueryHandler(
            IIndividualCustomerRepository individualCustomerRepository,
            IMapper mapper,
            IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<GetIndividualCustomerResponse> Handle(
            GetByIdIndividualCustomerQuery request, 
            CancellationToken cancellationToken)
        {
            await _businessRules.CustomerShouldExist(request.Id);

            var individualCustomer = await _individualCustomerRepository.GetAsync(
                predicate: ic => ic.Id == request.Id,
                cancellationToken: cancellationToken
            );

            return _mapper.Map<GetIndividualCustomerResponse>(individualCustomer);
        }
    }
} 