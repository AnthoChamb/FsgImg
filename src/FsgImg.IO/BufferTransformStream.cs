using FsgImg.Abstractions.Interfaces;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.IO
{
    public class BufferTransformStream : Stream
    {
        private readonly IBufferTransform _bufferTransform;

        public BufferTransformStream(Stream stream, IBufferTransform bufferTransform)
        {
            BaseStream = stream;
            _bufferTransform = bufferTransform;
        }

        public Stream BaseStream { get; }

        public override bool CanRead
        {
            get
            {
                return BaseStream.CanRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return BaseStream.CanSeek;
            }
        }

        public override bool CanTimeout
        {
            get
            {
                return BaseStream.CanTimeout;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return BaseStream.CanWrite;
            }
        }

        public override long Length
        {
            get
            {
                return BaseStream.Length;
            }
        }

        public override long Position
        {
            get
            {
                return BaseStream.Position;
            }

            set
            {
                BaseStream.Position = value;
            }
        }

        public override int ReadTimeout
        {
            get
            {
                return BaseStream.ReadTimeout;
            }

            set
            {
                BaseStream.ReadTimeout = value;
            }
        }

        public override int WriteTimeout
        {
            get
            {
                return BaseStream.WriteTimeout;
            }

            set
            {
                BaseStream.WriteTimeout = value;
            }
        }

        public override void Flush()
        {
            BaseStream.Flush();
        }

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return BaseStream.FlushAsync(cancellationToken);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var bytesRead = BaseStream.Read(buffer, offset, count);
            _bufferTransform.Transform(buffer, offset, bytesRead);
            return bytesRead;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var bytesRead = await BaseStream.ReadAsync(buffer, offset, count, cancellationToken);
            _bufferTransform.Transform(buffer, offset, bytesRead);
            return bytesRead;
        }

        public override int ReadByte()
        {
            return BaseStream.ReadByte();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return BaseStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            BaseStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _bufferTransform.Transform(buffer, offset, count);
            BaseStream.Write(buffer, offset, count);
        }

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            _bufferTransform.Transform(buffer, offset, count);
            return BaseStream.WriteAsync(buffer, offset, count);
        }

        public override void WriteByte(byte value)
        {
            BaseStream.WriteByte(value);
        }

        protected override void Dispose(bool disposing)
        {
            BaseStream.Dispose();
            base.Dispose(disposing);
        }
    }
}
