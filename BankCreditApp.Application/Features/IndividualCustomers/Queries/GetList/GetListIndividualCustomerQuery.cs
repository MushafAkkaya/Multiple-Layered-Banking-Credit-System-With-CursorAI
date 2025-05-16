using AutoMapper;
using BankCreditApp.Application.Features.IndividualCustomers.Dtos.Requests;
using BankCreditApp.Application.Features.IndividualCustomers.Dtos.Responses;
using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Core.Repositories;
using MediatR;

namespace BankCreditApp.Application.Features.IndividualCustomers.Queries.GetList;

public class GetListIndividualCustomerQuery : IRequest<GetListIndividualCustomerResponse>
{
    public GetListIndividualCustomerRequest Request { get; set; } = null!;

    public class GetListIndividualCustomerQueryHandler 
        : IRequestHandler<GetListIndividualCustomerQuery, GetListIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;

        public GetListIndividualCustomerQueryHandler(
            IIndividualCustomerRepository individualCustomerRepository,
            IMapper mapper)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
        }

        public async Task<GetListIndividualCustomerResponse> Handle(
            GetListIndividualCustomerQuery request, 
            CancellationToken cancellationToken)
        {
            var paginationParams = new PaginationParams
            {
                PageNumber = request.Request.PageNumber,
                PageSize = request.Request.PageSize
            };

            var result = await _individualCustomerRepository.GetListAsync(
                pagination: paginationParams,
                cancellationToken: cancellationToken
            );

            return new GetListIndividualCustomerResponse
            {
                Items = _mapper.Map<IList<GetIndividualCustomerResponse>>(result.Items),
                PageNumber = result.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalCount
            };
        }
    }
} 