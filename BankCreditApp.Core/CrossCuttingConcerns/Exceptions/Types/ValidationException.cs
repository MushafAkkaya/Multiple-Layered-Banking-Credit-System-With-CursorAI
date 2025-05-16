namespace BankCreditApp.Core.CrossCuttingConcerns.Exceptions.Types;

public class ValidationException : Exception
{
    public IEnumerable<ValidationExceptionModel> Errors { get; }

    public ValidationException(IEnumerable<ValidationExceptionModel> errors) : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }

    private static string BuildErrorMessage(IEnumerable<ValidationExceptionModel> errors)
    {
        return string.Join(Environment.NewLine, errors.Select(x => x.Message));
    }
}

public class ValidationExceptionModel
{
    public string Property { get; set; } = null!;
    public string Message { get; set; } = null!;
} 