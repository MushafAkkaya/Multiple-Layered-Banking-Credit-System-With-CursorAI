using MediatR;

namespace BankCreditApp.Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer;

public class CreateIndividualCustomerCommand : IRequest<CreatedIndividualCustomerResponse>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string IdentityNumber { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Occupation { get; set; } = default!;
    public decimal MonthlyIncome { get; set; }
} 