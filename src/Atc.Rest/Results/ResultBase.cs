namespace Atc.Rest.Results;

/// <summary>
/// Base class for strongly-typed action result wrappers.
/// </summary>
/// <remarks>
/// This class provides implicit conversion to <see cref="ActionResult"/> allowing derived types
/// to be returned directly from controller actions while maintaining type safety and encapsulation.
/// Derived classes typically represent specific HTTP response patterns (success, error, validation failure, etc.).
/// </remarks>
public abstract class ResultBase
{
    private readonly ActionResult result;

    /// <summary>
    /// Initializes a new instance of the <see cref="ResultBase"/> class.
    /// </summary>
    /// <param name="result">The underlying <see cref="ActionResult"/> to wrap.</param>
    protected ResultBase(ActionResult result)
    {
        this.result = result ?? throw new ArgumentNullException(nameof(result));
    }

    /// <summary>
    /// Performs an implicit conversion from a <see cref="ResultBase"/> to <see cref="ActionResult"/>.
    /// </summary>
    /// <param name="x">The result to convert.</param>
    /// <returns>The underlying <see cref="ActionResult"/>.</returns>
    [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
    [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "OK.")]
    public static implicit operator ActionResult(ResultBase x) => x.result;
}