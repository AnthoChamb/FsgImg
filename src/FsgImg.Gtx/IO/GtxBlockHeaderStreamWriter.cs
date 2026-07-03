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
    public class GtxBlockHeaderStreamWriter : IGtxBlockHeaderWriter
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IGtxBlockHeaderWriter _writer;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public GtxBlockHeaderStreamWriter(Stream stream, IGtxBlockHeaderByteArrayWriterFactory factory) : this(stream, factory, false)
        {
        }

        public GtxBlockHeaderStreamWriter(Stream stream, IGtxBlockHeaderByteArrayWriterFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(GtxConstants.GtxBlockHeaderSize);
            _writer = factory.Create(_buffer, 0, GtxConstants.GtxBlockHeaderSize);
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

        public void Write(IGtxBlockHeader gtxBlockHeader)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(GtxBlockHeaderStreamWriter).FullName);
            }

            _writer.Write(gtxBlockHeader);

            _stream.Write(_buffer, 0, GtxConstants.GtxBlockHeaderSize);
        }

        public async Task WriteAsync(IGtxBlockHeader gtxBlockHeader, CancellationToken cancellationToken = default)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(GtxBlockHeaderStreamWriter).FullName);
            }

            await _writer.WriteAsync(gtxBlockHeader, cancellationToken);

            await _stream.WriteAsync(_buffer, 0, GtxConstants.GtxBlockHeaderSize, cancellationToken);
        }
    }
}
