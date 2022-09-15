// ReSharper disable CollectionNeverUpdated.Local
// ReSharper disable SuggestBaseTypeForParameter
namespace Atc.DotNet.Tests;

public class DotnetGlobalUsingsHelperTests : IAsyncLifetime
{
    private static readonly DirectoryInfo WorkingDirectory = new(
        Path.Combine(Path.GetTempPath(), "atc-integration-test-dotnet-global-usings-helper"));

    public Task InitializeAsync()
    {
        if (Directory.Exists(WorkingDirectory.FullName))
        {
            Directory.Delete(WorkingDirectory.FullName, recursive: true);
        }

        Directory.CreateDirectory(WorkingDirectory.FullName);

        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        if (Directory.Exists(WorkingDirectory.FullName))
        {
            Directory.Delete(WorkingDirectory.FullName, recursive: true);
        }

        return Task.CompletedTask;
    }

    [Fact]
    public async Task CreateOrUpdate_Create_NoRequired()
    {
        // Arrange
        var required = new List<string>();
        var expectedContent = string.Empty;

        // Atc
        DotnetGlobalUsingsHelper.CreateOrUpdate(WorkingDirectory, required);

        // Assert
        var globalUsingFile = new FileInfo(Path.Combine(WorkingDirectory.FullName, "GlobalUsings.cs"));
        Assert.False(globalUsingFile.Exists);

        var actualContent = await FileHelper.ReadAllTextAsync(globalUsingFile);
        Assert.Equal(expectedContent, actualContent);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task CreateOrUpdate_SetSystemFirst_Create_NoRequired(
        bool setSystemFirst)
    {
        // Arrange
        var required = new List<string>();
        var expectedContent = string.Empty;

        // Atc
        DotnetGlobalUsingsHelper.CreateOrUpdate(WorkingDirectory, required, setSystemFirst);

        // Assert
        var globalUsingFile = new FileInfo(Path.Combine(WorkingDirectory.FullName, "GlobalUsings.cs"));
        Assert.False(globalUsingFile.Exists);

        var actualContent = await FileHelper.ReadAllTextAsync(globalUsingFile);
        Assert.Equal(expectedContent, actualContent);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public async Task CreateOrUpdate_SetSystemFirst_AddNamespaceSeparator_Create_NoRequired(
        bool setSystemFirst,
        bool addNamespaceSeparator)
    {
        // Arrange
        var required = new List<string>();
        var expectedContent = string.Empty;

        // Atc
        DotnetGlobalUsingsHelper.CreateOrUpdate(WorkingDirectory, required, setSystemFirst, addNamespaceSeparator);

        // Assert
        var globalUsingFile = new FileInfo(Path.Combine(WorkingDirectory.FullName, "GlobalUsings.cs"));
        Assert.False(globalUsingFile.Exists);

        var actualContent = await FileHelper.ReadAllTextAsync(globalUsingFile);
        Assert.Equal(expectedContent, actualContent);
    }

    [Fact]
    public async Task CreateOrUpdate_Create_WithRequired()
    {
        // Arrange
        var required = new List<string> { "System.Xml.Linq", "Atc.Data.Models" };
        var expectedContent = CreateSortedGlobalUsingsContent(required);

        // Atc
        DotnetGlobalUsingsHelper.CreateOrUpdate(WorkingDirectory, required);

        // Assert
        var globalUsingFile = new FileInfo(Path.Combine(WorkingDirectory.FullName, "GlobalUsings.cs"));
        Assert.True(globalUsingFile.Exists);

        var actualContent = await FileHelper.ReadAllTextAsync(globalUsingFile);
        Assert.Equal(expectedContent, actualContent);
    }

    [Fact]
    public async Task CreateOrUpdate_Update_NoRequired()
    {
        // Arrange
        var required = new List<string>();
        var expectedContent = CreateSortedGlobalUsingsContent();
        await CreateUnsortedGlobalUsingsFile(WorkingDirectory);

        // Atc
        DotnetGlobalUsingsHelper.CreateOrUpdate(WorkingDirectory, required);

        // Assert
        var globalUsingFile = new FileInfo(Path.Combine(WorkingDirectory.FullName, "GlobalUsings.cs"));
        Assert.True(globalUsingFile.Exists);

        var actualContent = await FileHelper.ReadAllTextAsync(globalUsingFile);
        Assert.Equal(expectedContent, actualContent);
    }

    [Fact]
    public async Task CreateOrUpdate_Update_WithRequired()
    {
        // Arrange
        var required = new List<string> { "System.Xml.Linq", "Atc.Data.Models" };
        var expectedContent = CreateSortedGlobalUsingsContentWithRequired();
        await CreateUnsortedGlobalUsingsFile(WorkingDirectory);

        // Atc
        DotnetGlobalUsingsHelper.CreateOrUpdate(WorkingDirectory, required);

        // Assert
        var globalUsingFile = new FileInfo(Path.Combine(WorkingDirectory.FullName, "GlobalUsings.cs"));
        Assert.True(globalUsingFile.Exists);

        var actualContent = await FileHelper.ReadAllTextAsync(globalUsingFile);
        Assert.Equal(expectedContent, actualContent);
    }

    [Fact]
    public void GetNewContentByReadingExistingIfExistAndMergeWithRequired_NoRequired()
    {
        // Arrange
        var required = new List<string>();
        var expectedContent = string.Empty;

        // Atc
        var actualContent = DotnetGlobalUsingsHelper.GetNewContentByReadingExistingIfExistAndMergeWithRequired(WorkingDirectory, required);

        // Assert
        var globalUsingFile = new FileInfo(Path.Combine(WorkingDirectory.FullName, "GlobalUsings.cs"));
        Assert.False(globalUsingFile.Exists);

        Assert.Equal(expectedContent, actualContent);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GetNewContentByReadingExistingIfExistAndMergeWithRequired_SetSystemFirst_NoRequired(
        bool setSystemFirst)
    {
        // Arrange
        var required = new List<string>();
        var expectedContent = string.Empty;

        // Atc
        var actualContent = DotnetGlobalUsingsHelper.GetNewContentByReadingExistingIfExistAndMergeWithRequired(WorkingDirectory, required, setSystemFirst);

        // Assert
        var globalUsingFile = new FileInfo(Path.Combine(WorkingDirectory.FullName, "GlobalUsings.cs"));
        Assert.False(globalUsingFile.Exists);

        Assert.Equal(expectedContent, actualContent);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void GetNewContentByReadingExistingIfExistAndMergeWithRequired_SetSystemFirst_AddNamespaceSeparator_NoRequired(
        bool setSystemFirst,
        bool addNamespaceSeparator)
    {
        // Arrange
        var required = new List<string>();
        var expectedContent = string.Empty;

        // Atc
        var actualContent = DotnetGlobalUsingsHelper.GetNewContentByReadingExistingIfExistAndMergeWithRequired(WorkingDirectory, required, setSystemFirst, addNamespaceSeparator);

        // Assert
        var globalUsingFile = new FileInfo(Path.Combine(WorkingDirectory.FullName, "GlobalUsings.cs"));
        Assert.False(globalUsingFile.Exists);

        Assert.Equal(expectedContent, actualContent);
    }

    [Fact]
    public void GetNewContentByReadingExistingIfExistAndMergeWithRequired_WithRequired()
    {
        // Arrange
        var required = new List<string> { "System.Xml.Linq", "Atc.Data.Models" };
        var expectedContent = CreateSortedGlobalUsingsContent(required);

        // Atc
        var actualContent = DotnetGlobalUsingsHelper.GetNewContentByReadingExistingIfExistAndMergeWithRequired(WorkingDirectory, required);

        // Assert
        var globalUsingFile = new FileInfo(Path.Combine(WorkingDirectory.FullName, "GlobalUsings.cs"));
        Assert.False(globalUsingFile.Exists);

        Assert.Equal(expectedContent, actualContent);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GetNewContentByReadingExistingIfExistAndMergeWithRequired_SetSystemFirst_WithRequired(
        bool setSystemFirst)
    {
        // Arrange
        var required = new List<string> { "System.Xml.Linq", "Atc.Data.Models" };
        var expectedContent = CreateSortedGlobalUsingsContent(required, setSystemFirst);

        // Atc
        var actualContent = DotnetGlobalUsingsHelper.GetNewContentByReadingExistingIfExistAndMergeWithRequired(WorkingDirectory, required, setSystemFirst);

        // Assert
        var globalUsingFile = new FileInfo(Path.Combine(WorkingDirectory.FullName, "GlobalUsings.cs"));
        Assert.False(globalUsingFile.Exists);

        Assert.Equal(expectedContent, actualContent);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void GetNewContentByReadingExistingIfExistAndMergeWithRequired_SetSystemFirst_AddNamespaceSeparator_WithRequired(
        bool setSystemFirst,
        bool addNamespaceSeparator)
    {
        // Arrange
        var required = new List<string> { "Atc.Data.Models", "System.Xml.Linq" };
        var expectedContent = CreateSortedGlobalUsingsContent(required, setSystemFirst, addNamespaceSeparator);

        // Atc
        var actualContent = DotnetGlobalUsingsHelper.GetNewContentByReadingExistingIfExistAndMergeWithRequired(WorkingDirectory, required, setSystemFirst, addNamespaceSeparator);

        // Assert
        var globalUsingFile = new FileInfo(Path.Combine(WorkingDirectory.FullName, "GlobalUsings.cs"));
        Assert.False(globalUsingFile.Exists);

        Assert.Equal(expectedContent, actualContent);
    }

    [SuppressMessage("Minor Code Smell", "S4136:Method overloads should be grouped together", Justification = "OK")]
    private static string CreateSortedGlobalUsingsContent(
        IReadOnlyCollection<string> required,
        bool setSystemFirst = true,
        bool addNamespaceSeparator = true)
    {
        var sb = new StringBuilder();
        if (setSystemFirst)
        {
            var rawSortedSystemUsings = required
                .Where(x => x.Equals("System", StringComparison.Ordinal) ||
                            x.StartsWith("System.", StringComparison.Ordinal))
                .OrderBy(x => x)
                .ToList();

            var rawSortedOtherUsings = required
                .Where(x => !x.Equals("System", StringComparison.Ordinal) &&
                            !x.StartsWith("System.", StringComparison.Ordinal))
                .OrderBy(x => x)
                .ToList();

            foreach (var item in rawSortedSystemUsings)
            {
                sb.AppendLine($"global using {item};", GlobalizationConstants.EnglishCultureInfo);
            }

            if (addNamespaceSeparator &&
                rawSortedSystemUsings.Any() &&
                rawSortedOtherUsings.Any())
            {
                sb.AppendLine();
            }

            CreateSortedGlobalUsingsContentAppend(sb, rawSortedOtherUsings, addNamespaceSeparator);
        }
        else
        {
            var rawSortedUsings = required
                .OrderBy(x => x)
                .ToList();

            CreateSortedGlobalUsingsContentAppend(sb, rawSortedUsings, addNamespaceSeparator);
        }

        return sb.ToString();
    }

    private static void CreateSortedGlobalUsingsContentAppend(
        StringBuilder sb,
        List<string> sortedUsings,
        bool addNamespaceSeparator)
    {
        var lastNamespacePrefix = string.Empty;
        foreach (var item in sortedUsings)
        {
            if (string.IsNullOrEmpty(lastNamespacePrefix))
            {
                lastNamespacePrefix = item.Split('.').First();
            }
            else
            {
                var namespacePrefix = item.Split('.').First();
                if (!lastNamespacePrefix.Equals(namespacePrefix, StringComparison.Ordinal))
                {
                    lastNamespacePrefix = namespacePrefix;
                    if (addNamespaceSeparator)
                    {
                        sb.AppendLine();
                    }
                }
            }

            sb.AppendLine($"global using {item};", GlobalizationConstants.EnglishCultureInfo);
        }
    }

    private static string CreateSortedGlobalUsingsContent()
    {
        var sb = new StringBuilder();
        sb.AppendLine("global using System;");
        sb.AppendLine("global using System.Collections.ObjectModel;");
        sb.AppendLine("global using System.Diagnostics;");
        sb.AppendLine("global using System.Diagnostics.CodeAnalysis;");
        sb.AppendLine("global using System.Globalization;");
        sb.AppendLine("global using System.Runtime.InteropServices;");
        sb.AppendLine("global using System.Text;");
        sb.AppendLine("global using System.Text.RegularExpressions;");
        sb.AppendLine("global using System.Xml;");
        sb.AppendLine("global using System.Xml.Linq;");
        sb.AppendLine();
        sb.AppendLine("global using Atc.DotNet.Models;");
        sb.AppendLine("global using Atc.Helpers;");
        sb.AppendLine();
        sb.AppendLine("global using Microsoft.AspNetCore.Mvc.ModelBinding;");
        sb.AppendLine("global using Microsoft.Extensions.Logging;");
        sb.AppendLine("global using Microsoft.Extensions.Logging.Abstractions;");

        return sb.ToString();
    }

    private static string CreateSortedGlobalUsingsContentWithRequired()
    {
        var sb = new StringBuilder();
        sb.AppendLine("global using System;");
        sb.AppendLine("global using System.Collections.ObjectModel;");
        sb.AppendLine("global using System.Diagnostics;");
        sb.AppendLine("global using System.Diagnostics.CodeAnalysis;");
        sb.AppendLine("global using System.Globalization;");
        sb.AppendLine("global using System.Runtime.InteropServices;");
        sb.AppendLine("global using System.Text;");
        sb.AppendLine("global using System.Text.RegularExpressions;");
        sb.AppendLine("global using System.Xml;");
        sb.AppendLine("global using System.Xml.Linq;");
        sb.AppendLine();
        sb.AppendLine("global using Atc.Data.Models;");
        sb.AppendLine("global using Atc.DotNet.Models;");
        sb.AppendLine("global using Atc.Helpers;");
        sb.AppendLine();
        sb.AppendLine("global using Microsoft.AspNetCore.Mvc.ModelBinding;");
        sb.AppendLine("global using Microsoft.Extensions.Logging;");
        sb.AppendLine("global using Microsoft.Extensions.Logging.Abstractions;");

        return sb.ToString();
    }

    private static Task CreateUnsortedGlobalUsingsFile(
        DirectoryInfo workingDirectory)
    {
        var file = new FileInfo(Path.Combine(workingDirectory.FullName, "GlobalUsings.cs"));

        var sb = new StringBuilder();
        sb.AppendLine("global using System;");
        sb.AppendLine("global using System.Collections.ObjectModel;");
        sb.AppendLine("global using Microsoft.Extensions.Logging;");
        sb.AppendLine("global using System.Diagnostics.CodeAnalysis;");
        sb.AppendLine("global using System.Diagnostics;");
        sb.AppendLine("global using System.Text;");
        sb.AppendLine("global using System.Diagnostics;");
        sb.AppendLine("global using System.Diagnostics;");
        sb.AppendLine();
        sb.AppendLine("global using System.Globalization;");
        sb.AppendLine("global using Microsoft.AspNetCore.Mvc.ModelBinding;");
        sb.AppendLine("global using System.Runtime.InteropServices;");
        sb.AppendLine("global using System.Text;");
        sb.AppendLine("global using Atc.DotNet.Models;");
        sb.AppendLine("global using System.Text.RegularExpressions;");
        sb.AppendLine("global using System.Xml;");
        sb.AppendLine("global using System.Xml.Linq;");
        sb.AppendLine();
        sb.AppendLine("global using Atc.Helpers;");
        sb.AppendLine();
        sb.AppendLine("global using Microsoft.Extensions.Logging.Abstractions;");

        return File.WriteAllTextAsync(file.FullName, sb.ToString(), Encoding.UTF8);
    }
}