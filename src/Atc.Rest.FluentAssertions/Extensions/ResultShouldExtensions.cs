using Atc.Rest.FluentAssertions;
using Atc.Rest.Results;

// ReSharper disable once CheckNamespace
namespace FluentAssertions
{
    /// <summary>
    /// Extensions for FluentAssertions that make testing Atc Rest handlers easier.
    /// </summary>
    public static class ResultShouldExtensions
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
}