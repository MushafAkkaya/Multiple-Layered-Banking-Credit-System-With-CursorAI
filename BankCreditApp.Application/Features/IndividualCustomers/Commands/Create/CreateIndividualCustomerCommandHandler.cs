using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using BankCreditApp.Domain.Entities;
using BankCreditApp.Application.Services.Repositories;
using BankCreditApp.Core.Security.Hashing;
using BankCreditApp.Application.Features.IndividualCustomers.Rules;
using BankCreditApp.Application.Features.IndividualCustomers.Dtos.Responses;

namespace BankCreditApp.Application.Features.IndividualCustomers.Commands.Create
{
    public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public CreateIndividualCustomerCommandHandler(
            IIndividualCustomerRepository individualCustomerRepository,
            IMapper mapper,
            IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreateIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            // Business Rules
            await _businessRules.CustomerIdentityNumberCannotBeDuplicated(request.Request.IdentityNumber);
            await _businessRules.CustomerMonthlyIncomeShouldBeValid(request.Request.MonthlyIncome);

            // Create ApplicationUser
            var applicationUser = new IndividualApplicationUser
            {
                Email = request.Request.Email,
                FirstName = request.Request.FirstName,
                LastName = request.Request.LastName,
                Status = true
            };

            // Create password hash
            HashingHelper.CreatePasswordHash(
                request.Request.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt
            );
            applicationUser.PasswordHash = passwordHash;
            applicationUser.PasswordSalt = passwordSalt;

            // Create Individual Customer
            var customer = _mapper.Map<IndividualCustomer>(request.Request);
            customer.CustomerNumber = GenerateCustomerNumber();
            customer.IsActive = true;
            customer.User = applicationUser;

            // Save to database
            await _individualCustomerRepository.AddAsync(customer, cancellationToken);

            // Return response
            return _mapper.Map<CreateIndividualCustomerResponse>(customer);
        }

        private static string GenerateCustomerNumber()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }
    }
} 