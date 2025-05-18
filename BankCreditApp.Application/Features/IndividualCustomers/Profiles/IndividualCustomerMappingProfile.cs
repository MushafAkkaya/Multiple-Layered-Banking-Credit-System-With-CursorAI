using AutoMapper;
using BankCreditApp.Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Application.Features.IndividualCustomers.Profiles;

public class IndividualCustomerMappingProfile : Profile
{
    public IndividualCustomerMappingProfile()
    {
        CreateMap<IndividualCustomer, CreatedIndividualCustomerResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
    }
} 