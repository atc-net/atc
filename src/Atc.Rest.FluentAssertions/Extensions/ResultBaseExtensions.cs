// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

/// <summary>
/// Extensions for FluentAssertions that make testing Atc Rest handlers easier.
/// </summary>
public static class ResultBaseExtensions
{
    /// <summary>
    /// Returns an <see cref="ResultAssertions"/> object that can be used
    /// to assert the current <paramref name="subject"/>.
    /// </summary>
    /// <param name="subject">The subject to assert against.</param>
    /// <returns>A <see cref="ResultAssertions"/>.</returns>
    public static ResultAssertions Should(this ResultBase subject)
        => new ResultAssertions(subject);
}