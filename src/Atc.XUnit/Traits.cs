namespace Atc.XUnit;

/// <summary>
/// Provides constants for xUnit test trait names and values.
/// </summary>
[SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "OK.")]
public static class Traits
{
    /// <summary>
    /// The "Category" trait name used to categorize tests.
    /// </summary>
    public const string Category = "Category";

    /// <summary>
    /// Provides standard category values for test traits.
    /// </summary>
    public static class Categories
    {
        /// <summary>
        /// Marks a test as an integration test that may be excluded from CI/CD pipelines.
        /// </summary>
        public const string Integration = "Integration";

        /// <summary>
        /// Marks a test to be skipped during Visual Studio Live Unit Testing.
        /// </summary>
        public const string SkipWhenLiveUnitTesting = "SkipWhenLiveUnitTesting";
    }
}