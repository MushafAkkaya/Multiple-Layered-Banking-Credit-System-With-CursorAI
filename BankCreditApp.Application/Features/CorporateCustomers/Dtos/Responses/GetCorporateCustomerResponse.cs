namespace BankCreditApp.Application.Features.CorporateCustomers.Dtos.Responses;

public class GetCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public string CustomerNumber { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public string TaxNumber { get; set; } = null!;
    public string TaxOffice { get; set; } = null!;
    public string CompanyType { get; set; } = null!;
    public string AuthorizedPersonName { get; set; } = null!;
    public decimal AnnualTurnover { get; set; }
    public DateTime EstablishmentDate { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
} 