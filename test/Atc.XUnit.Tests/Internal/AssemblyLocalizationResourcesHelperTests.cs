namespace Atc.XUnit.Tests.Internal;

public class AssemblyLocalizationResourcesHelperTests
{
    [Theory]
    [InlineData(false, "Foo", "Hello {0} world")]
    [InlineData(false, "FooAsAbbreviation1", "Hello world")]
    [InlineData(false, "Foo", "Hello {0} world {0}")]
    [InlineData(false, "Foo", "Hello {0} world {1}")]
    [InlineData(true, "Foo", "Hello world")]
    [InlineData(false, "Foo1", "Hello world")]
    [InlineData(false, "Foo1", "Hello {1} world")]
    [InlineData(false, "Foo1", "Hello {0} world {1}")]
    [InlineData(true, "Foo1", "Hello {0} world")]
    [InlineData(true, "Foo1", "Hello {0} world {0}")]
    [InlineData(false, "Foo2", "Hello world")]
    [InlineData(false, "Foo2", "Hello {0} world")]
    [InlineData(false, "Foo2", "Hello {0} world {0}")]
    [InlineData(true, "Foo2", "Hello {0} world {1}")]
    [InlineData(true, "Foo3", "Hello {0:format} world {1,10:format} {2,10}")]
    [InlineData(true, "Foo11", "{0:format}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}")]
    public void ValidateKeySuffixWithPlaceholdersTest(bool expected, string key, string value)
    {
        Assert.Equal(expected, AssemblyLocalizationResourcesHelper.ValidateKeySuffixWithPlaceholders(key, value));
    }

    [Theory]
    [InlineData(false, "Foo", "Hello {0} world", null)]
    [InlineData(true, "FooAsAbbreviation1", "Hello world", "AsAbbreviation")]
    [InlineData(false, "Foo", "Hello {0} world {0}", null)]
    [InlineData(false, "Foo", "Hello {0} world {1}", null)]
    [InlineData(true, "Foo", "Hello world", null)]
    [InlineData(false, "Foo1", "Hello world", null)]
    [InlineData(false, "Foo1", "Hello {1} world", null)]
    [InlineData(false, "Foo1", "Hello {0} world {1}", null)]
    [InlineData(true, "Foo1", "Hello {0} world", null)]
    [InlineData(true, "Foo1", "Hello {0} world {0}", null)]
    [InlineData(false, "Foo2", "Hello world", null)]
    [InlineData(false, "Foo2", "Hello {0} world", null)]
    [InlineData(false, "Foo2", "Hello {0} world {0}", null)]
    [InlineData(true, "Foo2", "Hello {0} world {1}", null)]
    [InlineData(true, "Foo3", "Hello {0:format} world {1,10:format} {2,10}", null)]
    [InlineData(true, "Foo11", "{0:format}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}", null)]
    public void ValidateKeySuffixWithPlaceholdersTest_AllowSuffixTerms(bool expected, string key, string value, string? allowSuffixTerm)
    {
        List<string>? allowSuffixTerms = null;
        if (allowSuffixTerm is not null)
        {
            allowSuffixTerms = new List<string>
            {
                allowSuffixTerm,
            };
        }

        Assert.Equal(expected, AssemblyLocalizationResourcesHelper.ValidateKeySuffixWithPlaceholders(key, value, allowSuffixTerms));
    }
}