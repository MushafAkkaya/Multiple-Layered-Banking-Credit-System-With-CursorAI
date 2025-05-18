namespace BankCreditApp.Application.Features.IndividualCustomers.Dtos.Requests;

public class CreateIndividualCustomerRequest
{
    // User Authentication Info
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    // Individual Customer Info
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string IdentityNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Occupation { get; set; } = null!;
    public decimal MonthlyIncome { get; set; }
} 