// ReSharper disable once CheckNamespace
namespace FluentValidation.Results;

/// <summary>
/// Extension methods for <see cref="ValidationResult"/> to convert to ASP.NET Core model state.
/// </summary>
internal static class ValidationResultExtensions
{
    /// <summary>
    /// Converts a FluentValidation <see cref="ValidationResult"/> to an ASP.NET Core <see cref="ModelStateDictionary"/>.
    /// </summary>
    /// <param name="validationResult">The validation result to convert.</param>
    /// <returns>A <see cref="ModelStateDictionary"/> containing the validation errors.</returns>
    public static ModelStateDictionary ToModelState(
        this ValidationResult validationResult)
    {
        var modelState = new ModelStateDictionary();
        validationResult.AddToModelState(modelState, string.Empty);
        return modelState;
    }
}