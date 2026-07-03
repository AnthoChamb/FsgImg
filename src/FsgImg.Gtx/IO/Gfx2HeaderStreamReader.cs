using CommunityToolkit.Diagnostics;
using FsgImg.Gtx.Abstractions;
using FsgImg.Gtx.Abstractions.Interfaces;
using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.IO.Extensions;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.IO
{
    public class Gfx2HeaderStreamReader : IGfx2HeaderReader
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IGfx2HeaderReader _reader;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public Gfx2HeaderStreamReader(Stream stream, IGfx2HeaderByteArrayReaderFactory factory) : this(stream, factory, false)
        {
        }

        public Gfx2HeaderStreamReader(Stream stream, IGfx2HeaderByteArrayReaderFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(GtxConstants.Gfx2HeaderSize);
            _reader = factory.Create(_buffer, 0, GtxConstants.Gfx2HeaderSize);
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
                _reader.Dispose();
                _disposed = true;
            }
        }

        public IGfx2Header Read()
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(Gfx2HeaderStreamReader).FullName);
            }

            _stream.ReadExactly(_buffer, 0, GtxConstants.Gfx2HeaderSize);

            return _reader.Read();
        }

        public async Task<IGfx2Header> ReadAsync(CancellationToken cancellationToken = default)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(Gfx2HeaderStreamReader).FullName);
            }

            await _stream.ReadExactlyAsync(_buffer, 0, GtxConstants.Gfx2HeaderSize, cancellationToken);

            return await _reader.ReadAsync(cancellationToken);
        }
    }
}
