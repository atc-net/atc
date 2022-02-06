// ReSharper disable once CheckNamespace
namespace FluentValidation.Results;

internal static class ValidationResultExtensions
{
    public static ModelStateDictionary ToModelState(this ValidationResult validationResult)
    {
        var modelState = new ModelStateDictionary();
        validationResult.AddToModelState(modelState, string.Empty);
        return modelState;
    }
}