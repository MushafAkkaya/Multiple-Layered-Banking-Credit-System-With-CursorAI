namespace BankCreditApp.Application.Features.IndividualCustomers.Dtos.Responses;

public class CreateIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string CustomerNumber { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string IdentityNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
} 