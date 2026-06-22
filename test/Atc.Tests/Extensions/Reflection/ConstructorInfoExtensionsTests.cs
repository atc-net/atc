namespace Atc.Tests.Extensions.Reflection;

public class ConstructorInfoExtensionsTests
{
    private sealed class SampleClass
    {
        // ReSharper disable once UnusedParameter.Local
        public SampleClass(
            int count,
            string name)
        {
        }
    }

    [Fact]
    public void BeautifyName_NoParams_ReturnsDotCtor()
    {
        var ctor = typeof(object).GetConstructor(Type.EmptyTypes)!;
        Assert.Equal(".ctor()", ctor.BeautifyName());
    }

    [Fact]
    public void BeautifyName_WithParams_IncludesParamTypes()
    {
        var ctor = typeof(SampleClass).GetConstructors().Single();
        var result = ctor.BeautifyName();
        Assert.Equal(".ctor(int count, string name)", result);
    }

    [Fact]
    public void BeautifyName_Null_Throws()
        => Assert.Throws<ArgumentNullException>(() =>
            ((ConstructorInfo)null!).BeautifyName());
}