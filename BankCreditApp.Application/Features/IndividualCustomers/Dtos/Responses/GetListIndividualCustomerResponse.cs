namespace BankCreditApp.Application.Features.IndividualCustomers.Dtos.Responses;

public class GetListIndividualCustomerResponse
{
    public IList<GetIndividualCustomerResponse> Items { get; set; } = null!;
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
} 