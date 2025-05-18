using AutoMapper;
using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Core.Security.Hashing;
using BankCreditApp.Domain.Entities;
using MediatR;

namespace BankCreditApp.Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer;

public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreatedIndividualCustomerResponse>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;

    public CreateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
    }

    public async Task<CreatedIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        // Create ApplicationUser
        var applicationUser = new IndividualApplicationUser
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Status = true
        };

        // Create password hash
        HashingHelper.CreatePasswordHash(
            request.Password,
            out byte[] passwordHash,
            out byte[] passwordSalt
        );
        applicationUser.PasswordHash = passwordHash;
        applicationUser.PasswordSalt = passwordSalt;

        // Create Individual Customer
        var customer = new IndividualCustomer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            IdentityNumber = request.IdentityNumber,
            DateOfBirth = request.DateOfBirth,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            Occupation = request.Occupation,
            MonthlyIncome = request.MonthlyIncome,
            Email = request.Email,
            CustomerNumber = GenerateCustomerNumber(),
            IsActive = true,
            User = applicationUser
        };

        await _individualCustomerRepository.AddAsync(customer);

        var response = _mapper.Map<CreatedIndividualCustomerResponse>(customer);
        return response;
    }

    private string GenerateCustomerNumber()
    {
        // Generate a unique 8-digit customer number
        return DateTime.Now.ToString("yyyyMMdd") + new Random().Next(1000, 9999).ToString();
    }
} 