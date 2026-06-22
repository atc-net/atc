// ReSharper disable ConvertToConstant.Local
namespace Atc.Tests.Extensions;

public class StreamExtensionsTests
{
    [Fact]
    public void CopyToStream()
    {
        // Arrange
        var input = "Hallo world".ToStream();

        // Act
        var actual = input.CopyToStream();

        // Assert
        Assert.Equal("Hallo world", actual.ToStringData());
    }

    [Fact]
    public void CopyToStream_BufferSize()
    {
        // Arrange
        var input = "Hallo world".ToStream();
        var bufferSize = 1024;

        // Act
        var actual = input.CopyToStream(bufferSize);

        // Assert
        Assert.Equal("Hallo world", actual.ToStringData());
    }

    [Fact]
    public void CopyToStream_NonSeekable_DoesNotThrow()
    {
        // Arrange — wrap a MemoryStream in a non-seekable decorator
        var inner = "Hallo world".ToStream();
        using var input = new NonSeekableStream(inner);

        // Act & Assert
        var actual = input.CopyToStream();
        Assert.Equal("Hallo world", actual.ToStringData());
    }

    [Fact]
    public void ToBytes()
    {
        // Arrange
        var input = "Hallo world".ToStream();

        // Act
        var buffer = input.ToBytes();
        var actual = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

        // Assert
        Assert.Equal("Hallo world", actual);
    }

    [Fact]
    public void ToBytes_NonSeekable_DoesNotThrow()
    {
        // Arrange
        var inner = "Hallo world".ToStream();
        using var input = new NonSeekableStream(inner);

        // Act
        var buffer = input.ToBytes();
        var actual = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

        // Assert
        Assert.Equal("Hallo world", actual);
    }

    [Fact]
    public void ToStringData()
    {
        // Arrange
        var input = "Hallo world".ToStream();

        // Act
        var actual = input.ToStringData();

        // Assert
        Assert.Equal("Hallo world", actual);
    }

    [Fact]
    public void ToStringData_DoesNotDisposeCallerStream()
    {
        // Arrange
        var input = "Hallo world".ToStream();

        // Act
        _ = input.ToStringData();

        // Assert — stream is still usable after the call
        Assert.True(input.CanRead);
    }

    [Fact]
    public void ToStringData_NonSeekable_DoesNotThrow()
    {
        // Arrange
        var inner = "Hallo world".ToStream();
        using var input = new NonSeekableStream(inner);

        // Act
        var actual = input.ToStringData();

        // Assert
        Assert.Equal("Hallo world", actual);
    }

    [Fact]
    public async Task CopyToStreamAsync()
    {
        // Arrange
        var input = "Hallo world".ToStream();

        // Act
        var actual = await input.CopyToStreamAsync();

        // Assert
        Assert.Equal("Hallo world", await actual.ToStringDataAsync());
    }

    [Fact]
    public async Task CopyToStreamAsync_BufferSize()
    {
        // Arrange
        var input = "Hallo world".ToStream();

        // Act
        var actual = await input.CopyToStreamAsync(bufferSize: 1024);

        // Assert
        Assert.Equal("Hallo world", await actual.ToStringDataAsync());
    }

    [Fact]
    public async Task CopyToStreamAsync_NonSeekable_DoesNotThrow()
    {
        // Arrange
        var inner = "Hallo world".ToStream();
        using var input = new NonSeekableStream(inner);

        // Act
        var actual = await input.CopyToStreamAsync();

        // Assert
        Assert.Equal("Hallo world", await actual.ToStringDataAsync());
    }

    [Fact]
    public async Task CopyToStreamAsync_Cancelled_ThrowsOperationCanceledException()
    {
        // Arrange
        var input = "Hallo world".ToStream();
        using var cts = new CancellationTokenSource();
        await cts.CancelAsync();

        // Act
        var ex = await Record.ExceptionAsync(() => (Task)input.CopyToStreamAsync(cancellationToken: cts.Token));

        // Assert
        Assert.IsAssignableFrom<OperationCanceledException>(ex);
    }

    [Fact]
    public async Task ToBytesAsync()
    {
        // Arrange
        var input = "Hallo world".ToStream();

        // Act
        var buffer = await input.ToBytesAsync();
        var actual = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

        // Assert
        Assert.Equal("Hallo world", actual);
    }

    [Fact]
    public async Task ToBytesAsync_NonSeekable_DoesNotThrow()
    {
        // Arrange
        var inner = "Hallo world".ToStream();
        using var input = new NonSeekableStream(inner);

        // Act
        var buffer = await input.ToBytesAsync();
        var actual = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

        // Assert
        Assert.Equal("Hallo world", actual);
    }

    [Fact]
    public async Task ToBytesAsync_Cancelled_ThrowsOperationCanceledException()
    {
        // Arrange
        var input = "Hallo world".ToStream();
        using var cts = new CancellationTokenSource();
        await cts.CancelAsync();

        // Act
        var ex = await Record.ExceptionAsync(() => (Task)input.ToBytesAsync(cts.Token));

        // Assert
        Assert.IsAssignableFrom<OperationCanceledException>(ex);
    }

    [Fact]
    public async Task ToStringDataAsync()
    {
        // Arrange
        var input = "Hallo world".ToStream();

        // Act
        var actual = await input.ToStringDataAsync();

        // Assert
        Assert.Equal("Hallo world", actual);
    }

    [Fact]
    public async Task ToStringDataAsync_DoesNotDisposeCallerStream()
    {
        // Arrange
        var input = "Hallo world".ToStream();

        // Act
        _ = await input.ToStringDataAsync();

        // Assert
        Assert.True(input.CanRead);
    }

    [Fact]
    public async Task ToStringDataAsync_NonSeekable_DoesNotThrow()
    {
        // Arrange
        var inner = "Hallo world".ToStream();
        using var input = new NonSeekableStream(inner);

        // Act
        var actual = await input.ToStringDataAsync();

        // Assert
        Assert.Equal("Hallo world", actual);
    }

    [Fact]
    public async Task ToStringDataAsync_Cancelled_ThrowsOperationCanceledException()
    {
        // Arrange
        var input = "Hallo world".ToStream();
        using var cts = new CancellationTokenSource();
        await cts.CancelAsync();

        // Act
        var ex = await Record.ExceptionAsync(() => (Task)input.ToStringDataAsync(cts.Token));

        // Assert
        Assert.IsAssignableFrom<OperationCanceledException>(ex);
    }

    /// <summary>
    /// Wraps a stream and hides seek capability to simulate non-seekable sources
    /// (e.g. network or compressed streams).
    /// </summary>
    private sealed class NonSeekableStream(Stream inner) : Stream
    {
        public override bool CanRead
            => inner.CanRead;

        public override bool CanSeek
            => false;

        public override bool CanWrite
            => false;

        public override long Length
            => throw new NotSupportedException();

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override void Flush()
            => inner.Flush();

        public override int Read(
            byte[] buffer,
            int offset,
            int count)
            => inner.Read(buffer, offset, count);

        public override long Seek(
            long offset,
            SeekOrigin origin)
            => throw new NotSupportedException();

        public override void SetLength(long value)
            => throw new NotSupportedException();

        public override void Write(
            byte[] buffer,
            int offset,
            int count)
            => throw new NotSupportedException();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                inner.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}