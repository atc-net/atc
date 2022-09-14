namespace Atc.Helpers;

public static class DataAnnotationHelper
{
    public static bool TryValidate<T>(
        T data,
        out IList<ValidationResult> validationResults,
        bool validateAllProperties = true)
        where T : new()
    {
        if (data is null)
        {
            validationResults = new List<ValidationResult>
            {
                new("Data is null"),
            };

            return false;
        }

        var validationContext = new ValidationContext(data);
        validationResults = new List<ValidationResult>();
        return Validator.TryValidateObject(data, validationContext, validationResults, validateAllProperties);
    }

    public static bool TryValidateOutToString<T>(
        T data,
        out string validationMessage,
        bool validateAllProperties = true)
        where T : new()
    {
        if (data is null)
        {
            validationMessage = "Data is null";
            return false;
        }

        var validationContext = new ValidationContext(data);
        var validationResults = new List<ValidationResult>();
        if (!Validator.TryValidateObject(data, validationContext, validationResults, validateAllProperties))
        {
            var sb = new StringBuilder();
            foreach (var validationResult in validationResults)
            {
                sb.AppendLine(validationResult.ErrorMessage);
            }

            validationMessage = sb.ToString();
            return false;
        }

        validationMessage = string.Empty;
        return true;
    }

    public static bool TryValidateOutToValidationException<T>(
        T data,
        out ValidationException validationException,
        bool validateAllProperties = true)
        where T : new()
    {
        if (data is null)
        {
            validationException = new ValidationException("Data is null");
            return false;
        }

        var validationContext = new ValidationContext(data);
        var validationResults = new List<ValidationResult>();
        if (!Validator.TryValidateObject(data, validationContext, validationResults, validateAllProperties))
        {
            var sb = new StringBuilder();
            foreach (var validationResult in validationResults)
            {
                sb.AppendLine(validationResult.ErrorMessage);
            }

            validationException = new ValidationException(sb.ToString());
            return false;
        }

        validationException = new ValidationException();
        return true;
    }
}