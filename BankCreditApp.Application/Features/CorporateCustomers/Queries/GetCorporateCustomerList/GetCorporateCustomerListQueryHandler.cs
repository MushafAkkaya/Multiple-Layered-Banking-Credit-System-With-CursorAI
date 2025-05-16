using AutoMapper;
using BankCreditApp.Application.Features.CorporateCustomers.Dtos.Responses;
using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankCreditApp.Application.Features.CorporateCustomers.Queries.GetCorporateCustomerList;

public class GetCorporateCustomerListQueryHandler : IRequestHandler<GetCorporateCustomerListQuery, PaginatedList<GetCorporateCustomerResponse>>
{
    private readonly ICorporateCustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetCorporateCustomerListQueryHandler(ICorporateCustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<GetCorporateCustomerResponse>> Handle(GetCorporateCustomerListQuery request, CancellationToken cancellationToken)
    {
        var list = await _repository.GetListAsync(
            orderBy: q => q.OrderByDescending(x => x.CreatedDate),
            pagination: request.PaginationParams,
            cancellationToken: cancellationToken);
            
        return _mapper.Map<PaginatedList<GetCorporateCustomerResponse>>(list);
    }
} 