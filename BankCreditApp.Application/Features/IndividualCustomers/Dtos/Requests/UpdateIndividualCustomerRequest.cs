namespace BankCreditApp.Application.Features.IndividualCustomers.Dtos.Requests;

public class UpdateIndividualCustomerRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Occupation { get; set; } = null!;
    public decimal MonthlyIncome { get; set; }
} 