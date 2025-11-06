<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# System.IO

<br />

## DirectoryInfoExtensions
Provides extension methods for the DirectoryInfo class.

>```csharp
>public static class DirectoryInfoExtensions
>```

### Static Methods

#### CombineFileInfo
>```csharp
>FileInfo CombineFileInfo(this DirectoryInfo directoryInfo, string[] paths)
>```
><b>Summary:</b> Combines the directory path with additional sub-paths to create a FileInfo object.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The base directory information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`paths`&nbsp;&nbsp;-&nbsp;&nbsp;An array of sub-paths to combine with the base directory.<br />
>
><b>Returns:</b> A FileInfo object representing the combined path.
#### GetByteSize
>```csharp
>long GetByteSize(this DirectoryInfo directoryInfo, string searchPattern = *.*, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Calculates the total size in bytes of all files in the directory matching the search pattern.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory to calculate size for.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchPattern`&nbsp;&nbsp;-&nbsp;&nbsp;The search pattern to match file names against (e.g., "*.txt"). Defaults to "*.*" for all files.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;Specifies whether to search only the current directory or all subdirectories. Defaults to .<br />
>
><b>Returns:</b> The total size in bytes of all matching files.
#### GetFileInfo
>```csharp
>FileInfo GetFileInfo(this DirectoryInfo directoryInfo, string file)
>```
><b>Summary:</b> Creates a `System.IO.FileInfo` object for a file within the directory.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory containing the file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`file`&nbsp;&nbsp;-&nbsp;&nbsp;The file name (without path) to get information for.<br />
>
><b>Returns:</b> A `System.IO.FileInfo` object representing the combined directory and file name.
#### GetFilesCount
>```csharp
>long GetFilesCount(this DirectoryInfo directoryInfo, string searchPattern = *.*, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Counts the total number of files in the directory matching the search pattern.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory to search in.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchPattern`&nbsp;&nbsp;-&nbsp;&nbsp;The search pattern to match file names against (e.g., "*.txt"). Defaults to "*.*" for all files.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;Specifies whether to search only the current directory or all subdirectories. Defaults to .<br />
>
><b>Returns:</b> The total number of files found.
#### GetFilesForAuthorizedAccess
>```csharp
>FileInfo[] GetFilesForAuthorizedAccess(this DirectoryInfo directoryInfo, string searchPattern = *.*, SearchOption searchOption = TopDirectoryOnly)
>```
><b>Summary:</b> Gets all files matching the search pattern while gracefully skipping files and folders with unauthorized access.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory to search in.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchPattern`&nbsp;&nbsp;-&nbsp;&nbsp;The search pattern to match file names against (e.g., "*.txt"). Defaults to "*.*" for all files.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;Specifies whether to search only the current directory or all subdirectories. Defaults to .<br />
>
><b>Returns:</b> An array of `System.IO.FileInfo` objects representing the files found.
#### GetFoldersCount
>```csharp
>long GetFoldersCount(this DirectoryInfo directoryInfo, string searchPattern = *, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Counts the total number of subdirectories in the directory matching the search pattern.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory to search in.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchPattern`&nbsp;&nbsp;-&nbsp;&nbsp;The search pattern to match directory names against (e.g., "temp*"). Defaults to "*" for all directories.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;Specifies whether to search only the current directory or all subdirectories. Defaults to .<br />
>
><b>Returns:</b> The total number of subdirectories found.
#### GetPrettyByteSize
>```csharp
>string GetPrettyByteSize(this DirectoryInfo directoryInfo, string searchPattern = *.*, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Gets the byte size as pretty formatted text like '1.933.212.103 bytes'.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchPattern`&nbsp;&nbsp;-&nbsp;&nbsp;The search pattern.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;The search option.<br />
#### GetPrettySize
>```csharp
>string GetPrettySize(this DirectoryInfo directoryInfo, string searchPattern = *.*, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Gets the byte size as pretty formatted text like '1.82 GB'.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchPattern`&nbsp;&nbsp;-&nbsp;&nbsp;The search pattern.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;The search option.<br />

<br />

## FileInfoExtensions
Extension methods for the `System.IO.FileInfo` class.

>```csharp
>public static class FileInfoExtensions
>```

### Static Methods

#### ReadToByteArray
>```csharp
>byte[] ReadToByteArray(this FileInfo fileInfo)
>```
><b>Summary:</b> Reads all bytes from the file into a byte array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information representing the file to read.<br />
>
><b>Returns:</b> A byte array containing all data from the file.
#### ReadToByteArrayAsync
>```csharp
>Task<byte[]> ReadToByteArrayAsync(this FileInfo fileInfo, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously reads all bytes from the file into a byte array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information representing the file to read.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A cancellation token to observe while waiting for the asynchronous operation to complete.<br />
>
><b>Returns:</b> A task that represents the asynchronous read operation. The task result contains a byte array with all data from the file.
#### ReadToMemoryStream
>```csharp
>MemoryStream ReadToMemoryStream(this FileInfo fileInfo)
>```
><b>Summary:</b> Reads the file content into a `System.IO.MemoryStream`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information representing the file to read.<br />
>
><b>Returns:</b> A `System.IO.MemoryStream` containing the file content with position set to 0.
#### ReadToMemoryStreamAsync
>```csharp
>Task<MemoryStream> ReadToMemoryStreamAsync(this FileInfo fileInfo, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously reads the file content into a `System.IO.MemoryStream`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information representing the file to read.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A cancellation token to observe while waiting for the asynchronous operation to complete.<br />
>
><b>Returns:</b> A task that represents the asynchronous read operation. The task result contains a `System.IO.MemoryStream` with the file content and position set to 0.

<br />

## MemoryStreamExtensions
Extensions for the `System.IO.MemoryStream` class.

>```csharp
>public static class MemoryStreamExtensions
>```

### Static Methods

#### ToString
>```csharp
>string ToString(this MemoryStream stream, Encoding encoding = null)
>```
><b>Summary:</b> Converts the memory stream content to a string using the specified encoding.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`stream`&nbsp;&nbsp;-&nbsp;&nbsp;The memory stream to convert.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`encoding`&nbsp;&nbsp;-&nbsp;&nbsp;The encoding to use for the conversion. If , Unicode encoding is used.<br />
>
><b>Returns:</b> A string representation of the memory stream content.

<br />

## StreamExtensions
Extensions for the `System.IO.Stream` class.

>```csharp
>public static class StreamExtensions
>```

### Static Methods

#### CopyToStream
>```csharp
>Stream CopyToStream(this Stream stream, int bufferSize = 4096)
>```
><b>Summary:</b> Copies the contents of the stream to a new `System.IO.MemoryStream`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`stream`&nbsp;&nbsp;-&nbsp;&nbsp;The source stream to copy from. The stream position will be reset to 0 before copying.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`bufferSize`&nbsp;&nbsp;-&nbsp;&nbsp;The size of the buffer used for copying. Defaults to 4096 bytes.<br />
>
><b>Returns:</b> A new `System.IO.MemoryStream` containing the copied data with position set to 0.
#### ToBytes
>```csharp
>byte[] ToBytes(this Stream stream)
>```
><b>Summary:</b> Reads all bytes from the stream and returns them as a byte array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`stream`&nbsp;&nbsp;-&nbsp;&nbsp;The stream to read from. The stream position will be reset to 0 before reading.<br />
>
><b>Returns:</b> A byte array containing all data from the stream.
#### ToStringData
>```csharp
>string ToStringData(this Stream stream)
>```
><b>Summary:</b> Reads all content from the stream and converts it to a string using the default encoding.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`stream`&nbsp;&nbsp;-&nbsp;&nbsp;The stream to read from. The stream position will be reset to 0 before reading.<br />
>
><b>Returns:</b> A string containing all text content from the stream.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
