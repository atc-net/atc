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