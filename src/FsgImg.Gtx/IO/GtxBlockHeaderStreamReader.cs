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
    public class GtxBlockHeaderStreamReader : IGtxBlockHeaderReader
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IGtxBlockHeaderReader _reader;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public GtxBlockHeaderStreamReader(Stream stream, IGtxBlockHeaderByteArrayReaderFactory factory) : this(stream, factory, false)
        {
        }

        public GtxBlockHeaderStreamReader(Stream stream, IGtxBlockHeaderByteArrayReaderFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(GtxConstants.GtxBlockHeaderSize);
            _reader = factory.Create(_buffer, 0, GtxConstants.GtxBlockHeaderSize);
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

        public IGtxBlockHeader Read()
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(GtxBlockHeaderStreamReader).FullName);
            }

            _stream.ReadExactly(_buffer, 0, GtxConstants.GtxBlockHeaderSize);

            return _reader.Read();
        }

        public async Task<IGtxBlockHeader> ReadAsync(CancellationToken cancellationToken = default)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(GtxBlockHeaderStreamReader).FullName);
            }

            await _stream.ReadExactlyAsync(_buffer, 0, GtxConstants.GtxBlockHeaderSize, cancellationToken);

            return await _reader.ReadAsync(cancellationToken);
        }
    }
}
