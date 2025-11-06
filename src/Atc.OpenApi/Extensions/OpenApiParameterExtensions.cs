// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;

/// <summary>
/// Extension methods for <see cref="OpenApiParameter"/> collections.
/// </summary>
public static class OpenApiParameterExtensions
{
    /// <summary>
    /// Determines whether any parameter in the collection has a UUID format type.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to check.</param>
    /// <returns>True if any parameter has UUID format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
    public static bool HasFormatTypeUuid(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeUuid());
    }

    /// <summary>
    /// Determines whether any parameter in the collection has a byte format type.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to check.</param>
    /// <returns>True if any parameter has byte format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
    public static bool HasFormatTypeByte(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeByte());
    }

    /// <summary>
    /// Determines whether any parameter in the collection has a date format type.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to check.</param>
    /// <returns>True if any parameter has date format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
    public static bool HasFormatTypeDate(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeDate());
    }

    /// <summary>
    /// Determines whether any parameter in the collection has a date-time format type.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to check.</param>
    /// <returns>True if any parameter has date-time format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
    public static bool HasFormatTypeDateTime(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeDateTime());
    }

    /// <summary>
    /// Determines whether any parameter in the collection has a time format type.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to check.</param>
    /// <returns>True if any parameter has time format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
    public static bool HasFormatTypeTime(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeTime());
    }

    /// <summary>
    /// Determines whether any parameter in the collection has a timestamp format type.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to check.</param>
    /// <returns>True if any parameter has timestamp format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
    public static bool HasFormatTypeTimestamp(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeTimestamp());
    }

    /// <summary>
    /// Determines whether any parameter in the collection has an int32 format type.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to check.</param>
    /// <returns>True if any parameter has int32 format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
    public static bool HasFormatTypeInt32(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeInt32());
    }

    /// <summary>
    /// Determines whether any parameter in the collection has an int64 format type.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to check.</param>
    /// <returns>True if any parameter has int64 format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
    public static bool HasFormatTypeInt64(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeInt64());
    }

    /// <summary>
    /// Determines whether any parameter in the collection has an email format type.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to check.</param>
    /// <returns>True if any parameter has email format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
    public static bool HasFormatTypeEmail(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeEmail());
    }

    /// <summary>
    /// Determines whether any parameter in the collection has a URI format type.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to check.</param>
    /// <returns>True if any parameter has URI format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
    public static bool HasFormatTypeUri(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Any(x => x.Schema.IsFormatTypeUri());
    }

    /// <summary>
    /// Determines whether any parameter in the collection has a format type that maps to a type in the System namespace.
    /// This includes UUID, date, date-time, time, timestamp, and URI format types.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to check.</param>
    /// <returns>True if any parameter has a System namespace format type; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
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

    /// <summary>
    /// Determines whether any parameter in the collection has a format type that maps to a type in the System.ComponentModel.DataAnnotations namespace.
    /// This includes email and URI format types.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to check.</param>
    /// <returns>True if any parameter has a DataAnnotations namespace format type; otherwise, false.</returns>
    public static bool HasFormatTypeFromDataAnnotationsNamespace(this IList<OpenApiParameter> parameters)
    {
        return parameters.HasFormatTypeEmail() ||
               parameters.HasFormatTypeUri();
    }

    /// <summary>
    /// Retrieves all parameters from the collection that are located in the route (path).
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to filter.</param>
    /// <returns>A list of parameters that are path parameters.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
    public static List<OpenApiParameter> GetAllFromRoute(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Where(x => x.In == ParameterLocation.Path).ToList();
    }

    /// <summary>
    /// Retrieves all parameters from the collection that are located in the header.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to filter.</param>
    /// <returns>A list of parameters that are header parameters.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
    public static List<OpenApiParameter> GetAllFromHeader(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Where(x => x.In == ParameterLocation.Header).ToList();
    }

    /// <summary>
    /// Retrieves all parameters from the collection that are located in the query string.
    /// </summary>
    /// <param name="parameters">The collection of <see cref="OpenApiParameter"/> to filter.</param>
    /// <returns>A list of parameters that are query parameters.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameters"/> is null.</exception>
    public static List<OpenApiParameter> GetAllFromQuery(this IList<OpenApiParameter> parameters)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return parameters.Where(x => x.In == ParameterLocation.Query).ToList();
    }
}