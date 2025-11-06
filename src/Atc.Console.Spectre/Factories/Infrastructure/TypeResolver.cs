namespace Atc.Console.Spectre.Factories.Infrastructure;

/// <summary>
/// Implementation of <see cref="ITypeResolver"/> that resolves types using an <see cref="IServiceProvider"/>.
/// </summary>
public sealed class TypeResolver : ITypeResolver, IDisposable
{
    private readonly IServiceProvider provider;

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeResolver"/> class.
    /// </summary>
    /// <param name="provider">The service provider to use for type resolution.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="provider"/> is null.</exception>
    public TypeResolver(IServiceProvider provider)
    {
        this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
    }

    /// <summary>
    /// Resolves an instance of the specified type using the service provider.
    /// </summary>
    /// <param name="type">The type to resolve.</param>
    /// <returns>An instance of the specified type, or null if <paramref name="type"/> is null.</returns>
    public object? Resolve(Type? type)
        => type is null
            ? null
            : provider.GetRequiredService(type);

    /// <summary>
    /// Disposes the service provider if it implements <see cref="IDisposable"/>.
    /// </summary>
    public void Dispose()
    {
        if (provider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}