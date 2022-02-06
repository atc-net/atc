namespace Atc.CodeDocumentation;

/// <summary>
/// TypeComments.
/// </summary>
public class TypeComments
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TypeComments"/> class.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="commentLookup">The comment lookup.</param>
    [SuppressMessage("Microsoft.Security", "CA2208:Instantiate argument exceptions correctly", Justification = "OK.")]
    public TypeComments(Type type, ILookup<string, XmlDocumentComment>? commentLookup)
    {
        this.Type = type ?? throw new ArgumentNullException(nameof(type));
        this.CommentLookup = commentLookup ?? throw new ArgumentNullException(nameof(commentLookup));
        if (type.FullName is null)
        {
            throw new ArgumentNullOrDefaultPropertyException(nameof(type.FullName));
        }
    }

    /// <summary>
    /// Gets the type.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    public Type Type { get; }

    /// <summary>
    /// Gets the comment lookup.
    /// </summary>
    /// <value>
    /// The comment lookup.
    /// </value>
    public ILookup<string, XmlDocumentComment> CommentLookup { get; }

    /// <summary>
    /// Gets the namespace.
    /// </summary>
    /// <value>
    /// The namespace.
    /// </value>
    public string Namespace => Type.Namespace!;

    /// <summary>
    /// Gets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name => Type.Name;

    /// <summary>
    /// Gets the full name.
    /// </summary>
    /// <value>
    /// The full name.
    /// </value>
    public string FullName => Type.FullName!;

    /// <summary>
    /// Gets the name of the beautify HTML.
    /// </summary>
    /// <value>
    /// The name of the beautify HTML.
    /// </value>
    public string BeautifyHtmlName => Type.BeautifyName(useFullName: false, useHtmlFormat: true);

    /// <summary>
    /// Gets a value indicating whether this instance has comments.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance has comments; otherwise, <c>false</c>.
    /// </value>
    public bool HasComments => CommentLookup.Contains(Type.FullName ?? throw new InvalidOperationException());

    /// <summary>
    /// Gets the XML document comments.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "OK.")]
    public XmlDocumentComment[]? GetXmlDocumentComments()
    {
        return CommentLookup.Contains(Type.FullName ?? throw new InvalidOperationException())
            ? CommentLookup[Type.FullName].ToArray()
            : null;
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A string that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return this.Name;
    }

    internal MethodInfo[] GetMethods()
    {
        return Type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any() && !x.IsPrivate)
            .ToArray();
    }

    internal PropertyInfo[] GetProperties()
    {
        return Type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.GetProperty | BindingFlags.SetProperty)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any())
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
    }

    internal FieldInfo[] GetFields()
    {
        return Type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.GetField | BindingFlags.SetField)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any() && !x.IsPrivate)
            .ToArray();
    }

    internal EventInfo[] GetEvents()
    {
        return Type.GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any())
            .ToArray();
    }

    internal FieldInfo[] GetStaticFields()
    {
        return Type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.GetField | BindingFlags.SetField)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any() && !x.IsPrivate)
            .ToArray();
    }

    internal PropertyInfo[] GetStaticProperties()
    {
        return Type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.GetProperty | BindingFlags.SetProperty)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any())
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
    }

    internal MethodInfo[] GetStaticMethods()
    {
        return Type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any() && !x.IsPrivate)
            .ToArray();
    }

    internal EventInfo[] GetStaticEvents()
    {
        return Type.GetEvents(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any())
            .ToArray();
    }
}