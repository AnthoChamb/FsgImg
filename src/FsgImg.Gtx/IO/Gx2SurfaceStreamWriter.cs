using CommunityToolkit.Diagnostics;
using FsgImg.Gtx.Abstractions;
using FsgImg.Gtx.Abstractions.Interfaces;
using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.IO
{
    public class Gx2SurfaceStreamWriter : IGx2SurfaceWriter
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IGx2SurfaceWriter _writer;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public Gx2SurfaceStreamWriter(Stream stream, IGx2SurfaceByteArrayWriterFactory factory) : this(stream, factory, false)
        {
        }

        public Gx2SurfaceStreamWriter(Stream stream, IGx2SurfaceByteArrayWriterFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(GtxConstants.Gx2SurfaceHeaderSize);
            _writer = factory.Create(_buffer, 0, GtxConstants.Gx2SurfaceHeaderSize);
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

        public void Write(IGx2Surface gx2Surface)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(Gx2SurfaceStreamWriter).FullName);
            }

            _writer.Write(gx2Surface);

            _stream.Write(_buffer, 0, GtxConstants.Gx2SurfaceHeaderSize);
        }

        public async Task WriteAsync(IGx2Surface gx2Surface, CancellationToken cancellationToken = default)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(Gx2SurfaceStreamWriter).FullName);
            }

            await _writer.WriteAsync(gx2Surface, cancellationToken);

            await _stream.WriteAsync(_buffer, 0, GtxConstants.Gx2SurfaceHeaderSize, cancellationToken);
        }
    }
}
