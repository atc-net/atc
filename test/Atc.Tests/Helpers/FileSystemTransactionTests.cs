namespace Atc.Tests.Helpers;

/// <summary>
/// An operation that fails half-way leaves the file system as it found it: the files it overwrote or deleted are put
/// back, the files and the folders it created are removed. An operation that succeeds keeps what it wrote.
/// </summary>
public sealed class FileSystemTransactionTests : IDisposable
{
    private readonly string root = Path.Combine(Path.GetTempPath(), "atc-filesystem-transaction-" + Guid.NewGuid().ToString("N"));

    public FileSystemTransactionTests()
        => Directory.CreateDirectory(root);

    public void Dispose()
    {
        if (Directory.Exists(root))
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [Theory]
    [InlineData(0, "after")]
    [InlineData(1, "before")]
    public void Run_KeepsWhatASucceedingOperationWrote_AndPutsBackWhatAFailingOneWrote(
        int result,
        string expected)
    {
        var file = Path.Combine(root, "Program.cs");
        File.WriteAllText(file, "before");

        var returned = FileSystemTransaction.Run(() =>
        {
            FileSystemTransaction.WriteAllText(file, "after");
            return result;
        });

        Assert.Equal(result, returned);
        Assert.Equal(expected, File.ReadAllText(file));
        Assert.Null(FileSystemTransaction.Current);
    }

    [Fact]
    public void Run_WithACustomSuccessResult_KeepsWhatWasWritten()
    {
        var file = Path.Combine(root, "custom.txt");

        FileSystemTransaction.Run(
            () =>
            {
                FileSystemTransaction.WriteAllText(file, "kept");
                return 42;
            },
            successResult: 42);

        Assert.Equal("kept", File.ReadAllText(file));
    }

    [Fact]
    public void Run_WhenTheOperationThrows_PutsBackWhatWasWritten()
    {
        var file = Path.Combine(root, "thrown.txt");

        Assert.Throws<InvalidOperationException>(() => FileSystemTransaction.Run(() =>
        {
            FileSystemTransaction.WriteAllText(file, "written");
            throw new InvalidOperationException("Failed half-way");
        }));

        Assert.False(File.Exists(file));
    }

    [Fact]
    public void Dispose_WithoutCommit_PutsTheFileSystemBack()
    {
        var existing = Path.Combine(root, "Api.csproj");
        var deleted = Path.Combine(root, "Old.cs");
        var copied = Path.Combine(root, "Api.yaml");
        var binary = Path.Combine(root, "logo.bin");
        var source = Path.Combine(root, "source.yaml");
        File.WriteAllText(existing, "before");
        File.WriteAllText(deleted, "old");
        File.WriteAllText(source, "openapi: 3.0.3");
        var newFolder = Path.Combine(root, "src", "Api.Domain");

        using (var transaction = FileSystemTransaction.Begin())
        {
            Assert.Same(transaction, FileSystemTransaction.Current);
            FileSystemTransaction.WriteAllText(existing, "after");
            FileSystemTransaction.WriteAllText(existing, "after again");
            FileSystemTransaction.Copy(source, copied, overwrite: true);
            var bytes = new byte[] { 1, 2, 3 };
            FileSystemTransaction.WriteAllBytes(binary, bytes);
            FileSystemTransaction.Delete(deleted);
            FileSystemTransaction.CreateDirectory(newFolder);
            FileSystemTransaction.WriteAllText(Path.Combine(newFolder, "Program.cs"), "// new");

            // The operation reads back what it wrote
            Assert.Equal("after again", File.ReadAllText(existing));
        }

        Assert.Equal("before", File.ReadAllText(existing));
        Assert.Equal("old", File.ReadAllText(deleted));
        Assert.False(File.Exists(copied));
        Assert.False(File.Exists(binary));
        Assert.False(Directory.Exists(Path.Combine(root, "src")));
        Assert.True(File.Exists(source));
    }

    [Fact]
    public void WriteAllText_WithEncoding_IsPutBack()
    {
        var path = Path.Combine(root, "encoded.txt");
        var contents = "æøå";
        var encoding = Encoding.Unicode;

        using (FileSystemTransaction.Begin())
        {
            FileSystemTransaction.WriteAllText(path, contents, encoding);
            Assert.Equal(contents, File.ReadAllText(path, encoding));
        }

        Assert.False(File.Exists(path));
    }

    [Fact]
    public void Commit_KeepsWhatWasWritten()
    {
        var file = Path.Combine(root, "nested", "Api.csproj");

        using (var transaction = FileSystemTransaction.Begin())
        {
            FileSystemTransaction.CreateDirectory(Path.GetDirectoryName(file)!);
            FileSystemTransaction.WriteAllText(file, "written");
            Assert.True(transaction.HasChanges);
            transaction.Commit();
        }

        Assert.Equal("written", File.ReadAllText(file));
    }

    [Fact]
    public void TrackFile_And_TrackDirectory_RecordWritesMadeElsewhere()
    {
        var file = Path.Combine(root, "external.txt");
        var folder = Path.Combine(root, "external", "deep");

        using (var transaction = FileSystemTransaction.Begin())
        {
            transaction.TrackFile(file);
            transaction.TrackDirectory(folder);
            File.WriteAllText(file, "written by someone else");
            Directory.CreateDirectory(folder);
        }

        Assert.False(File.Exists(file));
        Assert.False(Directory.Exists(Path.Combine(root, "external")));
    }

    [Fact]
    public void Begin_Nests_AndRestoresTheOuterTransaction()
    {
        using var outer = FileSystemTransaction.Begin();
        using (var inner = FileSystemTransaction.Begin())
        {
            Assert.Same(inner, FileSystemTransaction.Current);
        }

        Assert.Same(outer, FileSystemTransaction.Current);
    }

    [Fact]
    public void WithoutATransaction_WritesAreMadeAsAlways()
    {
        var file = Path.Combine(root, "plain.txt");

        FileSystemTransaction.WriteAllText(file, "plain");

        Assert.Null(FileSystemTransaction.Current);
        Assert.Equal("plain", File.ReadAllText(file));
    }
}