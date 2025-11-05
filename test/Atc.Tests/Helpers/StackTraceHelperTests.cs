namespace Atc.Tests.Helpers;

public class StackTraceHelperTests
{
    [Fact]
    public void ContainsConstructor()
    {
        // Arrange
        var instance = new TestClassWithConstructor();

        // Act
        var actual = instance.WasCalledFromConstructor;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void ContainsConstructor_WithDrillDownFrameMax()
    {
        // Arrange
        var instance = new TestClassWithConstructorDrillDown();

        // Act
        var actual = instance.WasCalledFromConstructor;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void ContainsPropertyName()
    {
        // Arrange
        var instance = new TestClassWithProperty();

        // Act
        var actual = instance.CheckFromMethod();

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void ContainsPropertyName_WithDrillDownFrameMax()
    {
        // Arrange
        var instance = new TestClassWithPropertyDrillDown();

        // Act
        var actual = instance.CheckFromMethod();

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void ContainsPropertyGetterName()
    {
        // Arrange
        var instance = new TestClassWithGetter();

        // Act
        var actual = instance.TestProperty;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void ContainsPropertyGetterName_WithDrillDownFrameMax()
    {
        // Arrange
        var instance = new TestClassWithGetterDrillDown();

        // Act
        var actual = instance.TestProperty;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void ContainsPropertySetterName()
    {
        // Arrange
        var instance = new TestClassWithSetter();

        // Act
        instance.TestProperty = true;

        // Assert
        Assert.True(instance.WasCalledFromSetter);
    }

    [Fact]
    public void ContainsPropertySetterName_WithDrillDownFrameMax()
    {
        // Arrange
        var instance = new TestClassWithSetterDrillDown();

        // Act
        instance.TestProperty = true;

        // Assert
        Assert.True(instance.WasCalledFromSetter);
    }

    // Helper test classes
    private sealed class TestClassWithConstructor
    {
        public bool WasCalledFromConstructor { get; }

        public TestClassWithConstructor()
        {
            WasCalledFromConstructor = StackTraceHelper.ContainsConstructor();
        }
    }

    private sealed class TestClassWithConstructorDrillDown
    {
        public bool WasCalledFromConstructor { get; }

        public TestClassWithConstructorDrillDown()
        {
            WasCalledFromConstructor = StackTraceHelper.ContainsConstructor(drillDownFrameMax: 10);
        }
    }

    private sealed class TestClassWithProperty
    {
        public bool CheckFromMethod()
        {
            return TestProperty();
        }

        private bool TestProperty()
        {
            return StackTraceHelper.ContainsPropertyName(nameof(TestProperty));
        }
    }

    private sealed class TestClassWithPropertyDrillDown
    {
        public bool CheckFromMethod()
        {
            return TestProperty();
        }

        private bool TestProperty()
        {
            return StackTraceHelper.ContainsPropertyName(nameof(TestProperty), drillDownFrameMax: 10);
        }
    }

    private sealed class TestClassWithGetter
    {
        public bool TestProperty => StackTraceHelper.ContainsPropertyGetterName(nameof(TestProperty));
    }

    private sealed class TestClassWithGetterDrillDown
    {
        public bool TestProperty => StackTraceHelper.ContainsPropertyGetterName(nameof(TestProperty), drillDownFrameMax: 10);
    }

    private sealed class TestClassWithSetter
    {
        private bool testValue;

        public bool WasCalledFromSetter { get; private set; }

        public bool TestProperty
        {
            get => testValue;
            set
            {
                testValue = value;
                WasCalledFromSetter = StackTraceHelper.ContainsPropertySetterName(nameof(TestProperty));
            }
        }
    }

    private sealed class TestClassWithSetterDrillDown
    {
        private bool testValue;

        public bool WasCalledFromSetter { get; private set; }

        public bool TestProperty
        {
            get => testValue;
            set
            {
                testValue = value;
                WasCalledFromSetter = StackTraceHelper.ContainsPropertySetterName(nameof(TestProperty), drillDownFrameMax: 10);
            }
        }
    }
}