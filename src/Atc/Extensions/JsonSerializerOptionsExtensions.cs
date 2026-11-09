// ReSharper disable once CheckNamespace
namespace System.Text.Json;

/// <summary>
/// Extension methods for <see cref="JsonSerializerOptions"/>.
/// </summary>
public static class JsonSerializerOptionsExtensions
{
    /// <summary>
    /// Copies every setting and converter from <paramref name="source"/> onto <paramref name="target"/>,
    /// so <paramref name="target"/> serializes the same way.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use it where the options instance cannot be replaced, only configured, e.g. ASP.NET Core's
    /// <c>JsonOptions.JsonSerializerOptions</c>:
    /// <c>services.Configure&lt;JsonOptions&gt;(o =&gt; JsonSerializerOptionsFactory.Create().CopyTo(o.SerializerOptions))</c>.
    /// Where a new instance is fine, use the <see cref="JsonSerializerOptions(JsonSerializerOptions)"/> copy constructor instead.
    /// </para>
    /// <para>
    /// The converters of <paramref name="target"/> are replaced by those of <paramref name="source"/>.
    /// <see cref="JsonSerializerOptions.TypeInfoResolver"/> is only copied when <paramref name="source"/> has one,
    /// so a resolver that <paramref name="target"/> needs (as ASP.NET Core's options do) is kept.
    /// The obsolete <c>IgnoreNullValues</c> is not copied; <see cref="JsonSerializerOptions.DefaultIgnoreCondition"/> is.
    /// </para>
    /// </remarks>
    /// <param name="source">The options to copy from.</param>
    /// <param name="target">The options to copy onto; must not have been used for serialization yet.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="target"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">Thrown when <paramref name="target"/> is read-only, i.e. already used for serialization.</exception>
    public static void CopyTo(
        this JsonSerializerOptions source,
        JsonSerializerOptions target)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (target is null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        if (target.IsReadOnly)
        {
            throw new InvalidOperationException("The target JsonSerializerOptions is read-only, as it has already been used for serialization.");
        }

        target.AllowDuplicateProperties = source.AllowDuplicateProperties;
        target.AllowOutOfOrderMetadataProperties = source.AllowOutOfOrderMetadataProperties;
        target.AllowTrailingCommas = source.AllowTrailingCommas;
        target.DefaultBufferSize = source.DefaultBufferSize;
        target.DefaultIgnoreCondition = source.DefaultIgnoreCondition;
        target.DictionaryKeyPolicy = source.DictionaryKeyPolicy;
        target.Encoder = source.Encoder;
        target.IgnoreReadOnlyFields = source.IgnoreReadOnlyFields;
        target.IgnoreReadOnlyProperties = source.IgnoreReadOnlyProperties;
        target.IncludeFields = source.IncludeFields;
        target.IndentCharacter = source.IndentCharacter;
        target.IndentSize = source.IndentSize;
        target.MaxDepth = source.MaxDepth;
        target.NewLine = source.NewLine;
        target.NumberHandling = source.NumberHandling;
        target.PreferredObjectCreationHandling = source.PreferredObjectCreationHandling;
        target.PropertyNameCaseInsensitive = source.PropertyNameCaseInsensitive;
        target.PropertyNamingPolicy = source.PropertyNamingPolicy;
        target.ReadCommentHandling = source.ReadCommentHandling;
        target.ReferenceHandler = source.ReferenceHandler;
        target.RespectNullableAnnotations = source.RespectNullableAnnotations;
        target.RespectRequiredConstructorParameters = source.RespectRequiredConstructorParameters;
        target.UnknownTypeHandling = source.UnknownTypeHandling;
        target.UnmappedMemberHandling = source.UnmappedMemberHandling;
        target.WriteIndented = source.WriteIndented;

        if (source.TypeInfoResolver is not null)
        {
            target.TypeInfoResolver = source.TypeInfoResolver;
        }

        target.Converters.Clear();
        foreach (var converter in source.Converters)
        {
            target.Converters.Add(converter);
        }
    }
}