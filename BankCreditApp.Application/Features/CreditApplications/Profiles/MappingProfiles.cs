using AutoMapper;
using BankCreditApp.Application.Features.CreditApplications.Dtos.Responses;
using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Application.Features.CreditApplications.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<IndividualCreditApplication, CreditApplicationResponse>()
            .ForMember(dest => dest.CreditTypeName, opt => opt.MapFrom(src => src.CreditType.Name));

        CreateMap<CorporateCreditApplication, CreditApplicationResponse>()
            .ForMember(dest => dest.CreditTypeName, opt => opt.MapFrom(src => src.CreditType.Name));

        CreateMap<PaginatedList<IndividualCreditApplication>, PaginatedList<CreditApplicationResponse>>();
        CreateMap<PaginatedList<CorporateCreditApplication>, PaginatedList<CreditApplicationResponse>>();
    }
} 