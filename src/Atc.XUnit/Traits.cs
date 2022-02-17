namespace Atc.XUnit;

[SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "OK.")]
public static class Traits
{
    public const string Category = "Category";

    public static class Categories
    {
        public const string Integration = "Integration";

        public const string SkipWhenLiveUnitTesting = "SkipWhenLiveUnitTesting";
    }
}