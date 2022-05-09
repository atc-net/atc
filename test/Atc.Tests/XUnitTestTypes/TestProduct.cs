namespace Atc.Tests.XUnitTestTypes;

public class TestProduct
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