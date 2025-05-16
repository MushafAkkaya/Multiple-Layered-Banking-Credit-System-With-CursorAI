namespace BankCreditApp.Application.Features.IndividualCustomers.Dtos.Requests;

public class GetListIndividualCustomerRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
} 