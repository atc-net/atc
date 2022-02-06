// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;

public static class OpenApiParameterExtensions
{
    public static bool HasFormatTypeUuid(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeUuid());
    }

    public static bool HasFormatTypeByte(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeByte());
    }

    public static bool HasFormatTypeDate(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeDate());
    }

    public static bool HasFormatTypeDateTime(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeDateTime());
    }

    public static bool HasFormatTypeTime(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeTime());
    }

    public static bool HasFormatTypeTimestamp(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeTimestamp());
    }

    public static bool HasFormatTypeInt32(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeInt32());
    }

    public static bool HasFormatTypeInt64(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeInt64());
    }

    public static bool HasFormatTypeEmail(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeEmail());
    }

    public static bool HasFormatTypeUri(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeUri());
    }

    public static bool HasFormatTypeFromSystemNamespace(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.HasFormatTypeUuid() ||
               parameters.HasFormatTypeDate() ||
               parameters.HasFormatTypeDateTime() ||
               parameters.HasFormatTypeTime() ||
               parameters.HasFormatTypeTimestamp() ||
               parameters.HasFormatTypeUri();
    }

    public static bool HasFormatTypeFromDataAnnotationsNamespace(this IList<OpenApiParameter> parameters)
    {
        return parameters.HasFormatTypeEmail() ||
               parameters.HasFormatTypeUri();
    }

    public static List<OpenApiParameter> GetAllFromRoute(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Where(x => x.In == ParameterLocation.Path).ToList();
    }

    public static List<OpenApiParameter> GetAllFromHeader(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Where(x => x.In == ParameterLocation.Header).ToList();
    }

    public static List<OpenApiParameter> GetAllFromQuery(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Where(x => x.In == ParameterLocation.Query).ToList();
    }
}