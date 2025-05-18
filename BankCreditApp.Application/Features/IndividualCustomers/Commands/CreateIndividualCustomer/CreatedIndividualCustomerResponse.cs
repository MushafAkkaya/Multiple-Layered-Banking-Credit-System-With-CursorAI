namespace BankCreditApp.Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer;

public class CreatedIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string CustomerNumber { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
} 