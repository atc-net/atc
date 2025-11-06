namespace Atc.Helpers;

/// <summary>
/// Provides utility methods for validating objects using Data Annotations validation attributes.
/// </summary>
public static class DataAnnotationHelper
{
    /// <summary>
    /// Attempts to validate an object using Data Annotations and returns the validation results.
    /// </summary>
    /// <typeparam name="T">The type of object to validate.</typeparam>
    /// <param name="data">The object to validate.</param>
    /// <param name="validationResults">When this method returns, contains the validation results if validation failed; otherwise, an empty list.</param>
    /// <param name="validateAllProperties">If <see langword="true"/>, validates all properties; otherwise, validates only required properties.</param>
    /// <returns><see langword="true"/> if validation succeeded; otherwise, <see langword="false"/>.</returns>
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

    /// <summary>
    /// Attempts to validate an object and returns a formatted string of validation error messages.
    /// </summary>
    /// <typeparam name="T">The type of object to validate.</typeparam>
    /// <param name="data">The object to validate.</param>
    /// <param name="validationMessage">When this method returns, contains a formatted string of error messages if validation failed; otherwise, an empty string.</param>
    /// <param name="validateAllProperties">If <see langword="true"/>, validates all properties; otherwise, validates only required properties.</param>
    /// <returns><see langword="true"/> if validation succeeded; otherwise, <see langword="false"/>.</returns>
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

    /// <summary>
    /// Attempts to validate an object and returns a <see cref="ValidationException"/> containing error messages if validation fails.
    /// </summary>
    /// <typeparam name="T">The type of object to validate.</typeparam>
    /// <param name="data">The object to validate.</param>
    /// <param name="validationException">When this method returns, contains a <see cref="ValidationException"/> with error messages if validation failed; otherwise, an empty exception.</param>
    /// <param name="validateAllProperties">If <see langword="true"/>, validates all properties; otherwise, validates only required properties.</param>
    /// <returns><see langword="true"/> if validation succeeded; otherwise, <see langword="false"/>.</returns>
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