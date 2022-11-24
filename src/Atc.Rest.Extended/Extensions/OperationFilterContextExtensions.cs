namespace Atc.Rest.Extended.Extensions;

public static class OperationFilterContextExtensions
{
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
}