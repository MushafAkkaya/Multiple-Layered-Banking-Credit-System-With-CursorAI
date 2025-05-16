namespace BankCreditApp.Application.Features.CorporateCustomers.Constants;

public static class CorporateCustomerMessages
{
    public const string NotFound = "Corporate customer not found";
    public const string AlreadyExists = "Corporate customer with this tax number already exists";
    public const string InvalidTaxNumber = "Invalid tax number";
    public const string InvalidAnnualTurnover = "Annual turnover must be greater than zero";
} 