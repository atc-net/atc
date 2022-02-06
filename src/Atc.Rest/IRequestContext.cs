namespace Atc.Rest;

public interface IRequestContext
{
    /// <summary>
    /// Gets the identity of the caller.
    /// </summary>
    string CallingIdentity { get; }

    /// <summary>
    /// Gets the identity of original caller when running as core service, otherwise its the same Identity.
    /// </summary>
    string OnBehalfOfIdentity { get; }

    string RequestId { get; }

    string CorrelationId { get; }

    CancellationToken RequestCancellationToken { get; }
}