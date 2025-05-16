namespace BankCreditApp.Application.Features.IndividualCustomers.Constants;

public static class IndividualCustomerMessages
{
    public const string NotFound = "Individual customer not found";
    public const string AlreadyExists = "Individual customer with this identity number already exists";
    public const string InvalidIdentityNumber = "Invalid identity number";
    public const string InvalidMonthlyIncome = "Monthly income must be greater than zero";
} 