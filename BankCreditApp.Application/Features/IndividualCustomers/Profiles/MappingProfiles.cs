using AutoMapper;
using BankCreditApp.Application.Features.IndividualCustomers.Commands.Create;
using BankCreditApp.Application.Features.IndividualCustomers.Dtos.Requests;
using BankCreditApp.Application.Features.IndividualCustomers.Dtos.Responses;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Application.Features.IndividualCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateIndividualCustomerRequest, IndividualCustomer>();
        CreateMap<IndividualCustomer, CreateIndividualCustomerResponse>();
        
        CreateMap<UpdateIndividualCustomerRequest, IndividualCustomer>();
        CreateMap<IndividualCustomer, UpdateIndividualCustomerResponse>();
        
        CreateMap<IndividualCustomer, DeleteIndividualCustomerResponse>();
        CreateMap<IndividualCustomer, GetIndividualCustomerResponse>();
    }
} 