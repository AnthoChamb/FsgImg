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
    public class Gx2SurfaceStreamReader : IGx2SurfaceReader
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IGx2SurfaceReader _reader;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public Gx2SurfaceStreamReader(Stream stream, IGx2SurfaceByteArrayReaderFactory factory) : this(stream, factory, false)
        {
        }

        public Gx2SurfaceStreamReader(Stream stream, IGx2SurfaceByteArrayReaderFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(GtxConstants.Gx2SurfaceHeaderSize);
            _reader = factory.Create(_buffer, 0, GtxConstants.Gx2SurfaceHeaderSize);
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

        public IGx2Surface Read()
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(Gx2SurfaceStreamReader).FullName);
            }

            _stream.ReadExactly(_buffer, 0, GtxConstants.Gx2SurfaceHeaderSize);

            return _reader.Read();
        }

        public async Task<IGx2Surface> ReadAsync(CancellationToken cancellationToken = default)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(Gx2SurfaceStreamReader).FullName);
            }

            await _stream.ReadExactlyAsync(_buffer, 0, GtxConstants.Gx2SurfaceHeaderSize, cancellationToken);

            return await _reader.ReadAsync(cancellationToken);
        }
    }
}
