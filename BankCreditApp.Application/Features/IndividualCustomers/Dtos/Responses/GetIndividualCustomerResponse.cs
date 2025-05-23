namespace BankCreditApp.Application.Features.IndividualCustomers.Dtos.Responses;

public class GetIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string CustomerNumber { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string IdentityNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Occupation { get; set; } = null!;
    public decimal MonthlyIncome { get; set; }
    public DateTime CreatedDate { get; set; }
} 