using AutoMapper;
using BankCreditApp.Application.Features.CreditApplications.Dtos.Responses;
using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankCreditApp.Application.Features.CreditApplications.Queries.GetCustomerCreditApplications;

public class GetCustomerCreditApplicationsQueryHandler 
    : IRequestHandler<GetCustomerCreditApplicationsQuery, PaginatedCreditApplicationListResponse>
{
    private readonly IIndividualCreditApplicationRepository _individualRepository;
    private readonly ICorporateCreditApplicationRepository _corporateRepository;
    private readonly IMapper _mapper;

    public GetCustomerCreditApplicationsQueryHandler(
        IIndividualCreditApplicationRepository individualRepository,
        ICorporateCreditApplicationRepository corporateRepository,
        IMapper mapper)
    {
        _individualRepository = individualRepository;
        _corporateRepository = corporateRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedCreditApplicationListResponse> Handle(
        GetCustomerCreditApplicationsQuery request, 
        CancellationToken cancellationToken)
    {
        if (request.IsIndividual)
        {
            var applications = await _individualRepository.GetListAsync(
                predicate: x => x.IndividualCustomerId == request.CustomerId,
                orderBy: q => q.OrderByDescending(x => x.ApplicationDate),
                include: q => q.Include(x => x.CreditType),
                pagination: request.PaginationParams,
                cancellationToken: cancellationToken);

            return new PaginatedCreditApplicationListResponse
            {
                Items = _mapper.Map<List<CreditApplicationResponse>>(applications.Items),
                PageNumber = applications.PageNumber,
                TotalPages = applications.TotalPages,
                TotalCount = applications.TotalCount
            };
        }

        var corporateApplications = await _corporateRepository.GetListAsync(
            predicate: x => x.CorporateCustomerId == request.CustomerId,
            orderBy: q => q.OrderByDescending(x => x.ApplicationDate),
            include: q => q.Include(x => x.CreditType),
            pagination: request.PaginationParams,
            cancellationToken: cancellationToken);

        return new PaginatedCreditApplicationListResponse
        {
            Items = _mapper.Map<List<CreditApplicationResponse>>(corporateApplications.Items),
            PageNumber = corporateApplications.PageNumber,
            TotalPages = corporateApplications.TotalPages,
            TotalCount = corporateApplications.TotalCount
        };
    }
} 