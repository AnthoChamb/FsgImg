using CommunityToolkit.Diagnostics;
using FsgImg.Dds.Abstractions;
using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsHeaderDxt10StreamWriter : IDdsHeaderDxt10Writer
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IDdsHeaderDxt10Writer _writer;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsHeaderDxt10StreamWriter(Stream stream, IDdsHeaderDxt10ByteArrayWriterFactory factory) : this(stream, factory, false)
        {
        }

        public DdsHeaderDxt10StreamWriter(Stream stream, IDdsHeaderDxt10ByteArrayWriterFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(DdsConstants.DdsHeaderDxt10Size);
            _writer = factory.Create(_buffer, 0, DdsConstants.DdsHeaderDxt10Size);
            _leaveOpen = leaveOpen;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (!_leaveOpen)
                {
                    _stream.Dispose();
                }
                ArrayPool<byte>.Shared.Return(_buffer);
                _writer.Dispose();
                _disposed = true;
            }
        }

        public void Write(IDdsHeaderDxt10 ddsHeaderDxt10)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(DdsHeaderDxt10StreamWriter).FullName);
            }

            _writer.Write(ddsHeaderDxt10);

            _stream.Write(_buffer, 0, DdsConstants.DdsHeaderDxt10Size);
        }

        public async Task WriteAsync(IDdsHeaderDxt10 ddsHeaderDxt10, CancellationToken cancellationToken = default)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(DdsHeaderDxt10StreamWriter).FullName);
            }

            await _writer.WriteAsync(ddsHeaderDxt10, cancellationToken);

            await _stream.WriteAsync(_buffer, 0, DdsConstants.DdsHeaderDxt10Size, cancellationToken);
        }
    }
}
