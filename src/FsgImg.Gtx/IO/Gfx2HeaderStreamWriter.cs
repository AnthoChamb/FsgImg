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
    public class Gfx2HeaderStreamWriter : IGfx2HeaderWriter
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IGfx2HeaderWriter _writer;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public Gfx2HeaderStreamWriter(Stream stream, IGfx2HeaderByteArrayWriterFactory factory) : this(stream, factory, false)
        {
        }

        public Gfx2HeaderStreamWriter(Stream stream, IGfx2HeaderByteArrayWriterFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(GtxConstants.Gfx2HeaderSize);
            _writer = factory.Create(_buffer, 0, GtxConstants.Gfx2HeaderSize);
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

        public void Write(IGfx2Header gfx2Header)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(Gfx2HeaderStreamWriter).FullName);
            }

            _writer.Write(gfx2Header);

            _stream.Write(_buffer, 0, GtxConstants.Gfx2HeaderSize);
        }

        public async Task WriteAsync(IGfx2Header gfx2Header, CancellationToken cancellationToken = default)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(Gfx2HeaderStreamWriter).FullName);
            }

            await _writer.WriteAsync(gfx2Header, cancellationToken);

            await _stream.WriteAsync(_buffer, 0, GtxConstants.Gfx2HeaderSize, cancellationToken);
        }
    }
}
