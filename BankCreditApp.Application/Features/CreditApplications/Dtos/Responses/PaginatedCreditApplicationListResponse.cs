using BankCreditApp.Application.Features.CreditApplications.Dtos.Responses;

public class PaginatedCreditApplicationListResponse
{
    public IList<CreditApplicationResponse> Items { get; set; } = null!;
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
} 