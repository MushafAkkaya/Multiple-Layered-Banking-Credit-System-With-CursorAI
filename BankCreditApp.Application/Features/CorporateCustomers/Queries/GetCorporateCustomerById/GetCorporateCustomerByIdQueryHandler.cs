using AutoMapper;
using BankCreditApp.Application.Features.CorporateCustomers.Constants;
using BankCreditApp.Application.Features.CorporateCustomers.Dtos.Responses;
using BankCreditApp.Application.Services.Repositories;
using MediatR;

namespace BankCreditApp.Application.Features.CorporateCustomers.Queries.GetCorporateCustomerById;

public class GetCorporateCustomerByIdQueryHandler : IRequestHandler<GetCorporateCustomerByIdQuery, GetCorporateCustomerResponse>
{
    private readonly ICorporateCustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetCorporateCustomerByIdQueryHandler(ICorporateCustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetCorporateCustomerResponse> Handle(GetCorporateCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (customer == null) throw new Exception(CorporateCustomerMessages.NotFound);
        return _mapper.Map<GetCorporateCustomerResponse>(customer);
    }
} 