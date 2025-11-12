namespace Atc.CodeDocumentation;

/// <summary>
/// Represents a type along with its associated XML documentation comments and member information.
/// </summary>
public class TypeComments
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TypeComments"/> class.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="commentLookup">The comment lookup.</param>
    public TypeComments(
        Type type,
        ILookup<string, XmlDocumentComment>? commentLookup)
    {
        Type = type ?? throw new ArgumentNullException(nameof(type));
        CommentLookup = commentLookup ?? throw new ArgumentNullException(nameof(commentLookup));
        if (type.FullName is null)
        {
            throw new ArgumentNullOrDefaultPropertyException(nameof(type), nameof(type.FullName));
        }
    }

    /// <summary>
    /// Gets the <see cref="System.Type"/> being documented.
    /// </summary>
    public Type Type { get; }

    /// <summary>
    /// Gets the lookup table mapping class names to their XML documentation comments.
    /// </summary>
    public ILookup<string, XmlDocumentComment> CommentLookup { get; }

    /// <summary>
    /// Gets the namespace of the type.
    /// </summary>
    public string Namespace => Type.Namespace!;

    /// <summary>
    /// Gets the simple name of the type.
    /// </summary>
    public string Name => Type.Name;

    /// <summary>
    /// Gets the fully qualified name of the type.
    /// </summary>
    public string FullName => Type.FullName!;

    /// <summary>
    /// Gets the HTML-formatted beautified name of the type.
    /// </summary>
    public string BeautifyHtmlName
        => Type.BeautifyName(useFullName: false, useHtmlFormat: true);

    /// <summary>
    /// Gets a value indicating whether this type has XML documentation comments.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if documentation comments exist for this type; otherwise, <see langword="false"/>.
    /// </value>
    public bool HasComments
        => CommentLookup.Contains(Type.FullName ?? throw new InvalidOperationException());

    /// <summary>
    /// Retrieves all XML documentation comments associated with this type.
    /// </summary>
    /// <returns>An array of XML documentation comments, or <see langword="null"/> if no comments exist.</returns>
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "OK.")]
    public XmlDocumentComment[]? GetXmlDocumentComments()
        => CommentLookup.Contains(Type.FullName ?? throw new InvalidOperationException())
            ? CommentLookup[Type.FullName].ToArray()
            : null;

    /// <inheritdoc/>
    public override string ToString() => Name;

    internal MethodInfo[] GetMethods()
        => Type
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod)
            .Where(x => !x.IsSpecialName && !x.AnyCustomAttributes<ObsoleteAttribute>() && !x.IsPrivate)
            .ToArray();

    internal PropertyInfo[] GetProperties()
        => Type
            .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.GetProperty | BindingFlags.SetProperty)
            .Where(x => !x.IsSpecialName && !x.AnyCustomAttributes<ObsoleteAttribute>())
            .Where(y =>
            {
                var get = y.GetGetMethod(nonPublic: true);
                var set = y.GetSetMethod(nonPublic: true);
                if (get is not null && set is not null)
                {
                    return !(get.IsPrivate && set.IsPrivate);
                }

                if (get is not null)
                {
                    return !get.IsPrivate;
                }

                if (set is not null)
                {
                    return !set.IsPrivate;
                }

                return false;
            })
            .ToArray();

    internal FieldInfo[] GetFields()
        => Type
            .GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.GetField | BindingFlags.SetField)
            .Where(x => !x.IsSpecialName && !x.AnyCustomAttributes<ObsoleteAttribute>() && !x.IsPrivate)
            .ToArray();

    internal EventInfo[] GetEvents()
        => Type
            .GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Where(x => !x.IsSpecialName && !x.AnyCustomAttributes<ObsoleteAttribute>())
            .ToArray();

    internal FieldInfo[] GetStaticFields()
        => Type
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.GetField | BindingFlags.SetField)
            .Where(x => !x.IsSpecialName && !x.AnyCustomAttributes<ObsoleteAttribute>() && !x.IsPrivate)
            .ToArray();

    internal PropertyInfo[] GetStaticProperties()
        => Type
            .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.GetProperty | BindingFlags.SetProperty)
            .Where(x => !x.IsSpecialName && !x.AnyCustomAttributes<ObsoleteAttribute>())
            .Where(y =>
            {
                var get = y.GetGetMethod(nonPublic: true);
                var set = y.GetSetMethod(nonPublic: true);
                if (get is not null && set is not null)
                {
                    return !(get.IsPrivate && set.IsPrivate);
                }

                if (get is not null)
                {
                    return !get.IsPrivate;
                }

                if (set is not null)
                {
                    return !set.IsPrivate;
                }

                return false;
            })
            .ToArray();

    internal MethodInfo[] GetStaticMethods()
        => Type
            .GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod)
            .Where(x => !x.IsSpecialName && !x.AnyCustomAttributes<ObsoleteAttribute>() && !x.IsPrivate)
            .ToArray();

    internal EventInfo[] GetStaticEvents()
        => Type
            .GetEvents(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Where(x => !x.IsSpecialName && !x.AnyCustomAttributes<ObsoleteAttribute>())
            .ToArray();
}