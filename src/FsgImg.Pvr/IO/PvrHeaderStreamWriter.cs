using CommunityToolkit.Diagnostics;
using FsgImg.Pvr.Abstractions;
using FsgImg.Pvr.Abstractions.Interfaces;
using FsgImg.Pvr.Abstractions.Interfaces.Factories;
using FsgImg.Pvr.Abstractions.Interfaces.IO;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Pvr.IO
{
    public class PvrHeaderStreamWriter : IPvrHeaderWriter
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IPvrHeaderWriter _writer;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public PvrHeaderStreamWriter(Stream stream, IPvrHeaderByteArrayWriterFactory factory) : this(stream, factory, false)
        {
        }

        public PvrHeaderStreamWriter(Stream stream, IPvrHeaderByteArrayWriterFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(PvrConstants.PvrHeaderSize);
            _writer = factory.Create(_buffer, 0, PvrConstants.PvrHeaderSize);
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

        public void Write(IPvrHeader pvrHeader)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(PvrHeaderStreamWriter).FullName);
            }

            _writer.Write(pvrHeader);

            _stream.Write(_buffer, 0, PvrConstants.PvrHeaderSize);
        }

        public async Task WriteAsync(IPvrHeader pvrHeader, CancellationToken cancellationToken = default)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(PvrHeaderStreamWriter).FullName);
            }

            await _writer.WriteAsync(pvrHeader, cancellationToken);

            await _stream.WriteAsync(_buffer, 0, PvrConstants.PvrHeaderSize, cancellationToken);
        }
    }
}
