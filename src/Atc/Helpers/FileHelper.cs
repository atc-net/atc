// ReSharper disable GrammarMistakeInComment
namespace Atc.Helpers;

/// <summary>
/// File-related helper methods with safe wrappers around common I/O operations.
/// </summary>
/// <remarks>
/// - All text read/write operations use UTF-8 encoding.
/// - Methods that read from a non-existing file return an empty result rather than throwing.
/// - <see cref="GetFiles(string,string,SearchOption)"/> and its overload delegate to
///   an extension method <c>GetFilesForAuthorizedAccess</c> that skips folders/files
///   where access is unauthorized.
/// </remarks>
/// <example>
/// <code>
/// var dir = new DirectoryInfo(@"C:\Logs");
/// var files = FileHelper.GetFiles(dir, "*.log");
///
/// foreach (var file in files)
/// {
///     var lines = await FileHelper.ReadAllTextToLinesAsync(file, cancellationToken);
///     // process lines…
/// }
///
/// var output = new FileInfo(@"C:\out\data.txt");
/// await FileHelper.WriteAllTextAsync(output, "Hello", cancellationToken);
/// </code>
/// </example>
public static class FileHelper
{
    /// <summary>
    /// Line-break tokens recognized when splitting text into lines.
    /// </summary>
    public static readonly string[] LineBreaks = { "\r\n", "\r", "\n" };

    /// <summary>
    /// Gets files under <paramref name="path"/> that match <paramref name="searchPattern"/>,
    /// recursively if <paramref name="searchOption"/> is <see cref="SearchOption.AllDirectories"/>,
    /// skipping any files or directories where access is unauthorized.
    /// </summary>
    /// <param name="path">The root directory path.</param>
    /// <param name="searchPattern">The search pattern. Default is <c>*.*</c>.</param>
    /// <param name="searchOption">
    /// The directory search option. Default is <see cref="SearchOption.AllDirectories"/>.
    /// </param>
    /// <returns>Matching files with inaccessible paths skipped.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="path"/> is <see langword="null"/> or empty.</exception>
    /// <exception cref="DirectoryNotFoundException">Thrown if the directory does not exist.</exception>
    public static FileInfo[] GetFiles(
        string path,
        string searchPattern = "*.*",
        SearchOption searchOption = SearchOption.AllDirectories)
        => new DirectoryInfo(path).GetFilesForAuthorizedAccess(searchPattern, searchOption);

    /// <summary>
    /// Gets files under <paramref name="path"/> that match <paramref name="searchPattern"/>,
    /// recursively if <paramref name="searchOption"/> is <see cref="SearchOption.AllDirectories"/>,
    /// skipping any files or directories where access is unauthorized.
    /// </summary>
    /// <param name="path">The root directory.</param>
    /// <param name="searchPattern">The search pattern. Default is <c>*.*</c>.</param>
    /// <param name="searchOption">
    /// The directory search option. Default is <see cref="SearchOption.AllDirectories"/>.
    /// </param>
    /// <returns>Matching files with inaccessible paths skipped.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="path"/> is <see langword="null"/>.</exception>
    public static FileInfo[] GetFiles(
        DirectoryInfo path,
        string searchPattern = "*.*",
        SearchOption searchOption = SearchOption.AllDirectories)
        => path.GetFilesForAuthorizedAccess(searchPattern, searchOption);

    /// <summary>
    /// Reads the entire file as UTF-8 text.
    /// </summary>
    /// <param name="fileInfo">The file to read.</param>
    /// <returns>
    /// The file contents. If the file does not exist, returns <see cref="string.Empty"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    public static string ReadAllText(
        FileInfo fileInfo)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        return fileInfo.Exists
            ? File.ReadAllText(fileInfo.FullName, Encoding.UTF8)
            : string.Empty;
    }

    /// <summary>
    /// Asynchronously reads the entire file as UTF-8 text.
    /// </summary>
    /// <param name="fileInfo">The file to read.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// A task producing the file contents. If the file does not exist, the task returns <see cref="string.Empty"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    public static Task<string> ReadAllTextAsync(
        FileInfo fileInfo,
        CancellationToken cancellationToken = default)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        return fileInfo.Exists
            ? File.ReadAllTextAsync(fileInfo.FullName, Encoding.UTF8, cancellationToken)
            : Task.FromResult(string.Empty);
    }

    /// <summary>
    /// Reads the entire file as UTF-8 text and splits it into lines,
    /// preserving empty lines and original line-breaks boundaries.
    /// </summary>
    /// <param name="fileInfo">The file to read.</param>
    /// <returns>
    /// An array of lines. If the file does not exist, returns <see cref="Array.Empty{T}"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    public static string[] ReadAllTextToLines(
        FileInfo fileInfo)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (!fileInfo.Exists)
        {
            return Array.Empty<string>();
        }

        var content = File.ReadAllText(fileInfo.FullName, Encoding.UTF8);
        return content.Split(LineBreaks, StringSplitOptions.None);
    }

    /// <summary>
    /// Asynchronously reads the entire file as UTF-8 text and splits it into lines,
    /// preserving empty lines and original line-breaks boundaries.
    /// </summary>
    /// <param name="fileInfo">The file to read.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// A task producing an array of lines. If the file does not exist, returns <see cref="Array.Empty{T}"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    public static Task<string[]> ReadAllTextToLinesAsync(
        FileInfo fileInfo,
        CancellationToken cancellationToken = default)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        return InvokeReadAllTextToLinesAsync(fileInfo, cancellationToken);
    }

    /// <summary>
    /// Reads the file into a byte array.
    /// </summary>
    /// <param name="fileInfo">The file to read.</param>
    /// <returns>The file contents as a byte array.</returns>
    /// <exception cref="ArgumentNullException">Potentially thrown by the underlying extension method if <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    public static byte[] ReadToByteArray(
        FileInfo fileInfo)
        => fileInfo.ReadToByteArray();

    /// <summary>
    /// Asynchronously reads the file into a byte array.
    /// </summary>
    /// <param name="fileInfo">The file to read.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task producing the file contents as a byte array.</returns>
    public static Task<byte[]> ReadToByteArrayAsync(
        FileInfo fileInfo,
        CancellationToken cancellationToken = default)
        => fileInfo.ReadToByteArrayAsync(cancellationToken);

    /// <summary>
    /// Reads the file into a <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="fileInfo">The file to read.</param>
    /// <returns>A <see cref="MemoryStream"/> containing the file contents.</returns>
    public static MemoryStream ReadToMemoryStream(
        FileInfo fileInfo)
        => fileInfo.ReadToMemoryStream();

    /// <summary>
    /// Asynchronously reads the file into a <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="fileInfo">The file to read.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task producing a <see cref="MemoryStream"/> containing the file contents.</returns>
    public static Task<MemoryStream> ReadToMemoryStreamAsync(
        FileInfo fileInfo,
        CancellationToken cancellationToken = default)
        => fileInfo.ReadToMemoryStreamAsync(cancellationToken);

    /// <summary>
    /// Writes <paramref name="content"/> to <paramref name="fileInfo"/> using UTF-8 encoding.
    /// Creates the file if it does not exist, and overwrites if it does.
    /// </summary>
    /// <param name="fileInfo">The destination file.</param>
    /// <param name="content">The content to write.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    public static void WriteAllText(
        FileInfo fileInfo,
        string content)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        File.WriteAllText(fileInfo.FullName, content, Encoding.UTF8);
    }

    /// <summary>
    /// Asynchronously writes <paramref name="content"/> to <paramref name="fileInfo"/> using UTF-8 encoding.
    /// Creates the file if it does not exist, and overwrites if it does.
    /// </summary>
    /// <param name="fileInfo">The destination file.</param>
    /// <param name="content">The content to write.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the write has finished.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    public static Task WriteAllTextAsync(
        FileInfo fileInfo,
        string content,
        CancellationToken cancellationToken = default)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        return File.WriteAllTextAsync(fileInfo.FullName, content, Encoding.UTF8, cancellationToken);
    }

    /// <summary>
    /// Internal helper to implement <see cref="ReadAllTextToLinesAsync(FileInfo,System.Threading.CancellationToken)"/>.
    /// </summary>
    private static async Task<string[]> InvokeReadAllTextToLinesAsync(
        FileInfo fileInfo,
        CancellationToken cancellationToken = default)
    {
        if (!fileInfo.Exists)
        {
            return Array.Empty<string>();
        }

        var content = await File
            .ReadAllTextAsync(fileInfo.FullName, Encoding.UTF8, cancellationToken)
            .ConfigureAwait(false);
        return content.Split(LineBreaks, StringSplitOptions.None);
    }

    /// <summary>
    /// Writes <paramref name="model"/> to <paramref name="fileInfo"/> as JSON using default serializer options.
    /// Delegates to <see cref="FileHelper{T}.WriteModelToJsonFile(FileInfo,T)"/>.
    /// </summary>
    /// <typeparam name="T">The model type to serialize.</typeparam>
    /// <param name="fileInfo">The destination JSON file.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    public static void WriteModelToJsonFile<T>(
        FileInfo fileInfo,
        T model)
        where T : class
        => FileHelper<T>.WriteModelToJsonFile(fileInfo, model);

    /// <summary>
    /// Writes <paramref name="model"/> to <paramref name="fileInfo"/> as JSON using the provided serializer options.
    /// Delegates to <see cref="FileHelper{T}.WriteModelToJsonFile(FileInfo,T,JsonSerializerOptions)"/>.
    /// </summary>
    /// <typeparam name="T">The model type to serialize.</typeparam>
    /// <param name="fileInfo">The destination JSON file.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <param name="serializeOptions">The <see cref="JsonSerializerOptions"/> to use.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="fileInfo"/> or <paramref name="serializeOptions"/> is <see langword="null"/>.
    /// </exception>
    public static void WriteModelToJsonFile<T>(
        FileInfo fileInfo,
        T model,
        JsonSerializerOptions serializeOptions)
        where T : class
        => FileHelper<T>.WriteModelToJsonFile(fileInfo, model, serializeOptions);

    /// <summary>
    /// Serializes <paramref name="model"/> as JSON to a writable stream using default serializer options.
    /// Delegates to <see cref="FileHelper{T}.WriteModelToJsonFile(Stream,T)"/>.
    /// The stream is <b>not</b> disposed.
    /// </summary>
    /// <typeparam name="T">The model type to serialize.</typeparam>
    /// <param name="utf8Json">A writable stream that will receive UTF-8 JSON.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="utf8Json"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="utf8Json"/> is not writable.</exception>
    public static void WriteModelToJsonFile<T>(
        Stream utf8Json,
        T model)
        where T : class
        => FileHelper<T>.WriteModelToJsonFile(utf8Json, model);

    /// <summary>
    /// Serializes <paramref name="model"/> as JSON to a writable stream using the provided serializer options.
    /// Delegates to <see cref="FileHelper{T}.WriteModelToJsonFile(Stream,T,JsonSerializerOptions)"/>.
    /// The stream is <b>not</b> disposed.
    /// </summary>
    /// <typeparam name="T">The model type to serialize.</typeparam>
    /// <param name="utf8Json">A writable stream that will receive UTF-8 JSON.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <param name="serializeOptions">The <see cref="JsonSerializerOptions"/> to use.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="utf8Json"/> or <paramref name="serializeOptions"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="utf8Json"/> is not writable.</exception>
    public static void WriteModelToJsonFile<T>(
        Stream utf8Json,
        T model,
        JsonSerializerOptions serializeOptions)
        where T : class
        => FileHelper<T>.WriteModelToJsonFile(utf8Json, model, serializeOptions);

    /// <summary>
    /// Asynchronously writes <paramref name="model"/> to <paramref name="fileInfo"/> as JSON using default serializer options.
    /// Delegates to <see cref="FileHelper{T}.WriteModelToJsonFileAsync(FileInfo,T,System.Threading.CancellationToken)"/>.
    /// </summary>
    /// <typeparam name="T">The model type to serialize.</typeparam>
    /// <param name="fileInfo">The destination JSON file.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the write has finished.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    public static Task WriteModelToJsonFileAsync<T>(
        FileInfo fileInfo,
        T model,
        CancellationToken cancellationToken = default)
        where T : class
        => FileHelper<T>.WriteModelToJsonFileAsync(fileInfo, model, cancellationToken);

    /// <summary>
    /// Asynchronously writes <paramref name="model"/> to <paramref name="fileInfo"/> as JSON using the provided serializer options.
    /// Delegates to <see cref="FileHelper{T}.WriteModelToJsonFileAsync(FileInfo,T,JsonSerializerOptions,System.Threading.CancellationToken)"/>.
    /// </summary>
    /// <typeparam name="T">The model type to serialize.</typeparam>
    /// <param name="fileInfo">The destination JSON file.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <param name="serializeOptions">The <see cref="JsonSerializerOptions"/> to use.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the write has finished.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="fileInfo"/> or <paramref name="serializeOptions"/> is <see langword="null"/>.
    /// </exception>
    public static Task WriteModelToJsonFileAsync<T>(
        FileInfo fileInfo,
        T model,
        JsonSerializerOptions serializeOptions,
        CancellationToken cancellationToken = default)
        where T : class
        => FileHelper<T>.WriteModelToJsonFileAsync(fileInfo, model, serializeOptions, cancellationToken);

    /// <summary>
    /// Asynchronously serializes <paramref name="model"/> as JSON to a writable stream using default serializer options.
    /// Delegates to <see cref="FileHelper{T}.WriteModelToJsonFileAsync(Stream,T,System.Threading.CancellationToken)"/>.
    /// The stream is <b>not</b> disposed.
    /// </summary>
    /// <typeparam name="T">The model type to serialize.</typeparam>
    /// <param name="utf8Json">A writable stream that will receive UTF-8 JSON.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the write has finished.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="utf8Json"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="utf8Json"/> is not writable.</exception>
    public static Task WriteModelToJsonFileAsync<T>(
        Stream utf8Json,
        T model,
        CancellationToken cancellationToken = default)
        where T : class
        => FileHelper<T>.WriteModelToJsonFileAsync(utf8Json, model, cancellationToken);

    /// <summary>
    /// Asynchronously serializes <paramref name="model"/> as JSON to a writable stream using the provided options.
    /// Delegates to <see cref="FileHelper{T}.WriteModelToJsonFileAsync(Stream,T,JsonSerializerOptions,System.Threading.CancellationToken)"/>.
    /// The stream is <b>not</b> disposed.
    /// </summary>
    /// <typeparam name="T">The model type to serialize.</typeparam>
    /// <param name="utf8Json">A writable stream that will receive UTF-8 JSON.</param>
    /// <param name="model">The model instance to serialize.</param>
    /// <param name="serializeOptions">The <see cref="JsonSerializerOptions"/> to use.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the write has finished.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="utf8Json"/> or <paramref name="serializeOptions"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="utf8Json"/> is not writable.</exception>
    public static Task WriteModelToJsonFileAsync<T>(
        Stream utf8Json,
        T model,
        JsonSerializerOptions serializeOptions,
        CancellationToken cancellationToken = default)
        where T : class
        => FileHelper<T>.WriteModelToJsonFileAsync(utf8Json, model, serializeOptions, cancellationToken);
}