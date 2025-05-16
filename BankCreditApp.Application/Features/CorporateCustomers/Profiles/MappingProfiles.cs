using AutoMapper;
using BankCreditApp.Application.Features.CorporateCustomers.Dtos.Responses;
using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Application.Features.CorporateCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CorporateCustomer, GetCorporateCustomerResponse>();
        CreateMap<PaginatedList<CorporateCustomer>, PaginatedList<GetCorporateCustomerResponse>>();
    }
} 