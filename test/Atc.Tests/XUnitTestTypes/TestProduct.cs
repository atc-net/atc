namespace Atc.Tests.XUnitTestTypes;

internal sealed class TestProduct
{
    public TestProduct()
    {
        Currency = string.Empty;
        Price = 0;
    }

    [IsoCurrencySymbol]
    public string Currency { get; set; }

    public double Price { get; set; }
}