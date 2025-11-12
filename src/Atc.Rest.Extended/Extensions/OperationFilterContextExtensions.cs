namespace Atc.Rest.Extended.Extensions;

/// <summary>
/// Extension methods for <see cref="OperationFilterContext"/> in Swagger operation filters.
/// </summary>
public static class OperationFilterContextExtensions
{
    /// <summary>
    /// Gets attributes of the specified type from both the controller and action method.
    /// </summary>
    /// <typeparam name="T">The type of attribute to retrieve.</typeparam>
    /// <param name="context">The <see cref="OperationFilterContext"/> instance.</param>
    /// <returns>A collection of attributes found on the controller type and action method.</returns>
    public static IEnumerable<T> GetControllerAndActionAttributes<T>(
        this OperationFilterContext context)
        where T : Attribute
    {
        ArgumentNullException.ThrowIfNull(context);

        if (context.MethodInfo is null)
        {
            return Enumerable.Empty<T>();
        }

        var controllerAttributes = context.MethodInfo.DeclaringType?.GetTypeInfo().GetCustomAttributes<T>();
        var actionAttributes = context.MethodInfo.GetCustomAttributes<T>();

        var result = new List<T>(actionAttributes);
        if (controllerAttributes is not null)
        {
            result.AddRange(controllerAttributes);
        }

        return result;
    }

    public static List<T> GetControllerAndActionAttributesAsList<T>(
        this OperationFilterContext context)
        where T : Attribute
        => context
            .GetControllerAndActionAttributes<T>()
            .ToList();

    public static bool AnyControllerAndActionAttributes<T>(
        this OperationFilterContext context)
        where T : Attribute
        => context
            .GetControllerAndActionAttributes<T>()
            .Any();
}