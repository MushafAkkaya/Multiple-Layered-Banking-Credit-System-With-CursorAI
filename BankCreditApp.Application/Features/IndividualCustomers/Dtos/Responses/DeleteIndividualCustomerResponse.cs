namespace BankCreditApp.Application.Features.IndividualCustomers.Dtos.Responses;

public class DeleteIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string CustomerNumber { get; set; } = null!;
    public DateTime DeletedDate { get; set; }
} 