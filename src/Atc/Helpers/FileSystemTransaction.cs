namespace Atc.Helpers;

/// <summary>
/// Records file and folder changes so that an operation that fails half-way can leave the file system as it found
/// it - for example a scaffolding or migration command that writes several files into a project.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="Begin"/> opens a transaction for the current execution flow (it flows across <see langword="await"/>,
/// like <see cref="AsyncLocal{T}"/>). Each file is recorded before it is first written - its content, or that it was
/// not there - and so is each folder that gets created. Disposed without <see cref="Commit"/>, the files are put
/// back, the new files deleted and the new folders removed. Reads see the files as written, so an operation can read
/// back what it wrote.
/// </para>
/// <para>
/// Only writes made through the static members (<see cref="WriteAllText(string, string)"/>, <see cref="Copy"/>,
/// <see cref="CreateDirectory"/>, ...) or announced with <see cref="TrackFile"/> / <see cref="TrackDirectory"/> are
/// recorded; what an external process writes is not. Without an open transaction, the static members just write.
/// </para>
/// <para>
/// This is a best-effort undo, not an atomic file-system transaction: a file that cannot be restored (locked,
/// access denied) is skipped and the others are still restored.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// var exitCode = FileSystemTransaction.Run(() =>
/// {
///     FileSystemTransaction.CreateDirectory(projectFolder);
///     FileSystemTransaction.WriteAllText(Path.Combine(projectFolder, "Program.cs"), content);
///     return RunNextStep(); // non-zero: everything written above is put back
/// });
/// </code>
/// </example>
public sealed class FileSystemTransaction : IDisposable
{
    private static readonly AsyncLocal<FileSystemTransaction?> Ambient = new();

    private static readonly StringComparer PathComparer = IsWindows()
        ? StringComparer.OrdinalIgnoreCase
        : StringComparer.Ordinal;

    private readonly FileSystemTransaction? previous;
    private readonly Dictionary<string, byte[]?> originals = new(PathComparer);
    private readonly List<string> createdDirectories = new();
    private bool committed;
    private bool disposed;

    private FileSystemTransaction(FileSystemTransaction? previous)
        => this.previous = previous;

    /// <summary>
    /// Gets the transaction that writes on the current execution flow are recorded in, or <see langword="null"/>
    /// when none is open.
    /// </summary>
    public static FileSystemTransaction? Current => Ambient.Value;

    /// <summary>
    /// Gets a value indicating whether the transaction has recorded a change.
    /// </summary>
    public bool HasChanges
        => originals.Count > 0 || createdDirectories.Count > 0;

    /// <summary>
    /// Opens a transaction for the writes on the current execution flow until it is disposed. Transactions nest: the
    /// inner one is current until it is disposed, then the outer one is current again.
    /// </summary>
    /// <returns>The transaction; dispose it, after <see cref="Commit"/> to keep the changes.</returns>
    public static FileSystemTransaction Begin()
    {
        var transaction = new FileSystemTransaction(Ambient.Value);
        Ambient.Value = transaction;
        return transaction;
    }

    /// <summary>
    /// Runs an operation in a transaction: what it writes is kept when it returns <paramref name="successResult"/>
    /// (0 by default, as a process exit code), and put back otherwise or when it throws.
    /// </summary>
    /// <param name="operation">The operation; returns a result code.</param>
    /// <param name="successResult">The result code that means success.</param>
    /// <returns>The operation's result code.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="operation"/> is <see langword="null"/>.</exception>
    public static int Run(
        Func<int> operation,
        int successResult = 0)
    {
        if (operation is null)
        {
            throw new ArgumentNullException(nameof(operation));
        }

        using var transaction = Begin();
        var result = operation();
        if (result == successResult)
        {
            transaction.Commit();
        }

        return result;
    }

    /// <summary>
    /// Writes a text file as <see cref="File.WriteAllText(string, string)"/> does, recording it in the open transaction first.
    /// </summary>
    /// <param name="path">The file.</param>
    /// <param name="contents">The text to write.</param>
    public static void WriteAllText(
        string path,
        string contents)
    {
        Current?.TrackFile(path);
        File.WriteAllText(path, contents);
    }

    /// <summary>
    /// Writes a text file as <see cref="File.WriteAllText(string, string, Encoding)"/> does, recording it in the open
    /// transaction first.
    /// </summary>
    /// <param name="path">The file.</param>
    /// <param name="contents">The text to write.</param>
    /// <param name="encoding">The encoding to write the text with.</param>
    public static void WriteAllText(
        string path,
        string contents,
        Encoding encoding)
    {
        Current?.TrackFile(path);
        File.WriteAllText(path, contents, encoding);
    }

    /// <summary>
    /// Writes a binary file as <see cref="File.WriteAllBytes(string, byte[])"/> does, recording it in the open transaction first.
    /// </summary>
    /// <param name="path">The file.</param>
    /// <param name="bytes">The bytes to write.</param>
    public static void WriteAllBytes(
        string path,
        byte[] bytes)
    {
        Current?.TrackFile(path);
        File.WriteAllBytes(path, bytes);
    }

    /// <summary>
    /// Copies a file as <see cref="File.Copy(string, string, bool)"/> does, recording the destination in the open
    /// transaction first.
    /// </summary>
    /// <param name="sourceFileName">The file to copy.</param>
    /// <param name="destFileName">The copy.</param>
    /// <param name="overwrite">Whether an existing destination file is overwritten.</param>
    public static void Copy(
        string sourceFileName,
        string destFileName,
        bool overwrite)
    {
        Current?.TrackFile(destFileName);
        File.Copy(sourceFileName, destFileName, overwrite);
    }

    /// <summary>
    /// Deletes a file as <see cref="File.Delete(string)"/> does, recording it in the open transaction first so it can
    /// be restored.
    /// </summary>
    /// <param name="path">The file.</param>
    public static void Delete(string path)
    {
        Current?.TrackFile(path);
        File.Delete(path);
    }

    /// <summary>
    /// Creates a folder and the missing folders above it as <see cref="Directory.CreateDirectory(string)"/> does,
    /// recording the outermost new folder in the open transaction first.
    /// </summary>
    /// <param name="path">The folder to create.</param>
    /// <returns>The information of the created (or already existing) folder.</returns>
    public static DirectoryInfo CreateDirectory(string path)
    {
        Current?.TrackDirectory(path);
        return Directory.CreateDirectory(path);
    }

    /// <summary>
    /// Records a file before it is first changed (its content, or that it does not exist), so that it is restored
    /// when the transaction is not committed. Later calls for the same file are ignored.
    /// </summary>
    /// <param name="path">The file about to be written or deleted.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is <see langword="null"/> or empty.</exception>
    public void TrackFile(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentException("The path must be set.", nameof(path));
        }

        var fullPath = Path.GetFullPath(path);
        if (!originals.ContainsKey(fullPath))
        {
            originals[fullPath] = File.Exists(fullPath) ? File.ReadAllBytes(fullPath) : null;
        }
    }

    /// <summary>
    /// Records a folder before it is created: the outermost of it and its parents that does not exist yet is removed
    /// (with everything in it) when the transaction is not committed.
    /// </summary>
    /// <param name="path">The folder about to be created.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is <see langword="null"/> or empty.</exception>
    public void TrackDirectory(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentException("The path must be set.", nameof(path));
        }

        string? outermost = null;
        for (var directory = Path.GetFullPath(path);
             !string.IsNullOrEmpty(directory) && !Directory.Exists(directory);
             directory = Path.GetDirectoryName(directory))
        {
            outermost = directory;
        }

        if (outermost is not null && !createdDirectories.Contains(outermost, PathComparer))
        {
            createdDirectories.Add(outermost);
        }
    }

    /// <summary>
    /// Keeps the changes: disposing no longer puts them back.
    /// </summary>
    public void Commit()
        => committed = true;

    /// <summary>
    /// Puts back the recorded changes, unless committed, and closes the transaction.
    /// </summary>
    public void Dispose()
    {
        if (disposed)
        {
            return;
        }

        disposed = true;
        if (ReferenceEquals(Ambient.Value, this))
        {
            Ambient.Value = previous;
        }

        if (!committed)
        {
            Rollback();
        }
    }

    private static bool IsWindows()
#if NET5_0_OR_GREATER
        => OperatingSystem.IsWindows();
#else
        => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#endif

    private void Rollback()
    {
        foreach (var pair in originals)
        {
            try
            {
                if (pair.Value is null)
                {
                    if (File.Exists(pair.Key))
                    {
                        File.Delete(pair.Key);
                    }
                }
                else
                {
                    var directory = Path.GetDirectoryName(pair.Key);
                    if (!string.IsNullOrEmpty(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    File.WriteAllBytes(pair.Key, pair.Value);
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                // Restore what can be restored: one file that cannot be is no reason to leave the others
            }
        }

        for (var i = createdDirectories.Count - 1; i >= 0; i--)
        {
            try
            {
                if (Directory.Exists(createdDirectories[i]))
                {
                    Directory.Delete(createdDirectories[i], recursive: true);
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                // A folder that cannot be removed is left
            }
        }
    }
}