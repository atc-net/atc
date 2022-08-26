<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# System.IO

<br />

## DirectoryInfoExtensions

>```csharp
>public static class DirectoryInfoExtensions
>```

### Static Methods

#### GetByteSize
>```csharp
>long GetByteSize(this DirectoryInfo directoryInfo, string searchPattern = *.*, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Gets the byte size.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchPattern`&nbsp;&nbsp;-&nbsp;&nbsp;The search pattern.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;The search option.<br />
#### GetFilesCount
>```csharp
>long GetFilesCount(this DirectoryInfo directoryInfo, string searchPattern = *.*, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Gets the files count.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchPattern`&nbsp;&nbsp;-&nbsp;&nbsp;The search pattern.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;The search option.<br />
#### GetFoldersCount
>```csharp
>long GetFoldersCount(this DirectoryInfo directoryInfo, string searchPattern = *, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Gets the folders count.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchPattern`&nbsp;&nbsp;-&nbsp;&nbsp;The search pattern.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;The search option.<br />
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

>```csharp
>public static class FileInfoExtensions
>```

### Static Methods

#### ReadToByteArray
>```csharp
>byte[] ReadToByteArray(this FileInfo fileInfo)
>```
#### ReadToByteArrayAsync
>```csharp
>Task<byte[]> ReadToByteArrayAsync(this FileInfo fileInfo, CancellationToken cancellationToken = null)
>```
#### ReadToMemoryStream
>```csharp
>MemoryStream ReadToMemoryStream(this FileInfo fileInfo)
>```
#### ReadToMemoryStreamAsync
>```csharp
>Task<MemoryStream> ReadToMemoryStreamAsync(this FileInfo fileInfo, CancellationToken cancellationToken = null)
>```

<br />

## MemoryStreamExtensions
Extensions for the `System.IO.Stream` class.

>```csharp
>public static class MemoryStreamExtensions
>```

### Static Methods

#### ToString
>```csharp
>string ToString(this MemoryStream stream, Encoding encoding = null)
>```
><b>Summary:</b> Converts to string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`stream`&nbsp;&nbsp;-&nbsp;&nbsp;The stream.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`encoding`&nbsp;&nbsp;-&nbsp;&nbsp;The encoding.<br />

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
><b>Summary:</b> Copy to stream.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`stream`&nbsp;&nbsp;-&nbsp;&nbsp;The stream.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`bufferSize`&nbsp;&nbsp;-&nbsp;&nbsp;Size of the buffer.<br />
#### ToBytes
>```csharp
>byte[] ToBytes(this Stream stream)
>```
><b>Summary:</b> Converts to bytes.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`stream`&nbsp;&nbsp;-&nbsp;&nbsp;The stream.<br />
#### ToStringData
>```csharp
>string ToStringData(this Stream stream)
>```
><b>Summary:</b> Converts to string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`stream`&nbsp;&nbsp;-&nbsp;&nbsp;The stream.<br />
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
