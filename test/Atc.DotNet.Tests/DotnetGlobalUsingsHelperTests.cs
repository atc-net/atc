// ReSharper disable CollectionNeverUpdated.Local
// ReSharper disable SuggestBaseTypeForParameter
namespace Atc.DotNet.Tests;

[SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
public class DotnetGlobalUsingsHelperTests : IAsyncLifetime
{
    private static readonly DirectoryInfo WorkingDirectory = new(
        Path.Combine(Path.GetTempPath(), "atc-integration-test-dotnet-global-usings-helper"));

    public ValueTask InitializeAsync()
    {
        if (Directory.Exists(WorkingDirectory.FullName))
        {
            Directory.Delete(WorkingDirectory.FullName, recursive: true);
        }

        Directory.CreateDirectory(WorkingDirectory.FullName);

        return ValueTask.CompletedTask;
    }

    public ValueTask DisposeAsync()
    {
        if (Directory.Exists(WorkingDirectory.FullName))
        {
            Directory.Delete(WorkingDirectory.FullName, recursive: true);
        }

        return ValueTask.CompletedTask;
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

    [Fact]
    public void StyleCop1210_Scenario1()
    {
        // Arrange
        var required = new List<string>
        {
            "Contracts.PrintPlans",
            "Contracts.Printers",
            "Contracts.Orders",
            "Contracts.PrintLines",
            "Contracts.PrintServer",
            "Contracts.Products",
            "Contracts.PrintServerTypes",
        };

        const string expectedContent = @"global using Contracts.Orders;
global using Contracts.Printers;
global using Contracts.PrintLines;
global using Contracts.PrintPlans;
global using Contracts.PrintServer;
global using Contracts.PrintServerTypes;
global using Contracts.Products;
";

        // Atc
        var actualContent = DotnetGlobalUsingsHelper.GetNewContentByReadingExistingIfExistAndMergeWithRequired(WorkingDirectory, required);

        // Assert
        Assert.Equal(expectedContent, actualContent);
    }

    [Fact]
    public void StyleCop1210_Scenario2()
    {
        // Arrange
        var required = new List<string>
        {
            "System.CodeDom.Compiler",
            "System.ComponentModel.DataAnnotations",
            "System.Net",
            "Atc.Rest.Results",
            "Microsoft.AspNetCore.Authorization",
            "Microsoft.AspNetCore.Http",
            "Microsoft.AspNetCore.Mvc",
            "Sch.Oct.Api.Generated.Contracts",
            "Sch.Oct.Api.Generated.Contracts.Areas",
            "Sch.Oct.Api.Generated.Contracts.Batches",
            "Sch.Oct.Api.Generated.Contracts.Blocks",
            "Sch.Oct.Api.Generated.Contracts.Customers",
            "Sch.Oct.Api.Generated.Contracts.External",
            "Sch.Oct.Api.Generated.Contracts.LabelLayoutGroups",
            "Sch.Oct.Api.Generated.Contracts.LabelLayouts",
            "Sch.Oct.Api.Generated.Contracts.Locations",
            "Sch.Oct.Api.Generated.Contracts.Orders",
            "Sch.Oct.Api.Generated.Contracts.Printers",
            "Sch.Oct.Api.Generated.Contracts.PrintLines",
            "Sch.Oct.Api.Generated.Contracts.PrintPlans",
            "Sch.Oct.Api.Generated.Contracts.PrintServer",
            "Sch.Oct.Api.Generated.Contracts.PrintServerTypes",
            "Sch.Oct.Api.Generated.Contracts.Products",
        };

        const string expectedContent = @"global using System.CodeDom.Compiler;
global using System.ComponentModel.DataAnnotations;
global using System.Net;

global using Atc.Rest.Results;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;

global using Sch.Oct.Api.Generated.Contracts;
global using Sch.Oct.Api.Generated.Contracts.Areas;
global using Sch.Oct.Api.Generated.Contracts.Batches;
global using Sch.Oct.Api.Generated.Contracts.Blocks;
global using Sch.Oct.Api.Generated.Contracts.Customers;
global using Sch.Oct.Api.Generated.Contracts.External;
global using Sch.Oct.Api.Generated.Contracts.LabelLayoutGroups;
global using Sch.Oct.Api.Generated.Contracts.LabelLayouts;
global using Sch.Oct.Api.Generated.Contracts.Locations;
global using Sch.Oct.Api.Generated.Contracts.Orders;
global using Sch.Oct.Api.Generated.Contracts.Printers;
global using Sch.Oct.Api.Generated.Contracts.PrintLines;
global using Sch.Oct.Api.Generated.Contracts.PrintPlans;
global using Sch.Oct.Api.Generated.Contracts.PrintServer;
global using Sch.Oct.Api.Generated.Contracts.PrintServerTypes;
global using Sch.Oct.Api.Generated.Contracts.Products;
";

        // Atc
        var actualContent = DotnetGlobalUsingsHelper.GetNewContentByReadingExistingIfExistAndMergeWithRequired(WorkingDirectory, required);

        // Assert
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
                .OrderBy(x => x, StringComparer.Ordinal)
                .ToList();

            var rawSortedOtherUsings = required
                .Where(x => !x.Equals("System", StringComparison.Ordinal) &&
                            !x.StartsWith("System.", StringComparison.Ordinal))
                .OrderBy(x => x, StringComparer.Ordinal)
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
                .OrderBy(x => x, StringComparer.Ordinal)
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
                lastNamespacePrefix = item.Split('.')[0];
            }
            else
            {
                var namespacePrefix = item.Split('.')[0];
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
        sb.AppendLine();
        sb.AppendLine("global using static System.Console;");
        sb.AppendLine("global using static System.Math;");

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
        sb.AppendLine();
        sb.AppendLine("global using static System.Console;");
        sb.AppendLine("global using static System.Math;");

        return sb.ToString();
    }

    private static Task CreateUnsortedGlobalUsingsFile(
        DirectoryInfo workingDirectory)
    {
        var file = new FileInfo(Path.Combine(workingDirectory.FullName, "GlobalUsings.cs"));

        var sb = new StringBuilder();
        sb.AppendLine("global using static System.Console;");
        sb.AppendLine("global using static System.Math;");
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