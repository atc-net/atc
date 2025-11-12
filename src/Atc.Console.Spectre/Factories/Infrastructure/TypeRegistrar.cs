namespace Atc.Console.Spectre.Factories.Infrastructure;

/// <summary>
/// Implementation of <see cref="ITypeRegistrar"/> that registers types in an <see cref="IServiceCollection"/>.
/// </summary>
public sealed class TypeRegistrar : ITypeRegistrar
{
    private readonly IServiceCollection builder;

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeRegistrar"/> class.
    /// </summary>
    /// <param name="builder">The service collection to register types in.</param>
    public TypeRegistrar(IServiceCollection builder)
    {
        this.builder = builder;
    }

    /// <summary>
    /// Builds a <see cref="ITypeResolver"/> from the configured service collection.
    /// </summary>
    /// <returns>A new <see cref="ITypeResolver"/> instance.</returns>
    public ITypeResolver Build()
        => new TypeResolver(builder.BuildServiceProvider());

    /// <summary>
    /// Registers a service type with its implementation type as a singleton.
    /// </summary>
    /// <param name="service">The service type to register.</param>
    /// <param name="implementation">The implementation type.</param>
    public void Register(
        Type service,
        Type implementation)
        => builder.AddSingleton(service, implementation);

    /// <summary>
    /// Registers a service type with a specific instance as a singleton.
    /// </summary>
    /// <param name="service">The service type to register.</param>
    /// <param name="implementation">The implementation instance.</param>
    public void RegisterInstance(
        Type service,
        object implementation)
        => builder.AddSingleton(service, implementation);

    /// <summary>
    /// Registers a service type with a factory function as a singleton.
    /// </summary>
    /// <param name="service">The service type to register.</param>
    /// <param name="factory">The factory function to create instances.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="factory"/> is null.</exception>
    public void RegisterLazy(
        Type service,
        Func<object> factory)
    {
        if (factory is null)
        {
            throw new ArgumentNullException(nameof(factory));
        }

        builder.AddSingleton(service, _ => factory());
    }
}