namespace BankCreditApp.Application.Features.CorporateCustomers.Dtos.Requests;

public class UpdateCorporateCustomerRequest
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string AuthorizedPersonName { get; set; } = null!;
    public decimal AnnualTurnover { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
} 