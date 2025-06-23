using CommunityToolkit.Diagnostics;
using FsgImg.Dds.Abstractions;
using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.IO.Extensions;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsHeaderStreamReader : IDdsHeaderReader
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IDdsHeaderReader _reader;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsHeaderStreamReader(Stream stream, IDdsHeaderBufferReaderFactory factory) : this(stream, factory, false)
        {
        }

        public DdsHeaderStreamReader(Stream stream, IDdsHeaderBufferReaderFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(DdsConstants.DdsHeaderSize);
            _reader = factory.Create(_buffer, 0, DdsConstants.DdsHeaderSize);
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

        public IDdsHeader Read()
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(DdsHeaderStreamReader).FullName);
            }

            _stream.ReadExactly(_buffer, 0, DdsConstants.DdsHeaderSize);

            return _reader.Read();
        }

        public async Task<IDdsHeader> ReadAsync(CancellationToken cancellationToken = default)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(DdsHeaderStreamReader).FullName);
            }

            await _stream.ReadExactlyAsync(_buffer, 0, DdsConstants.DdsHeaderSize, cancellationToken);

            return await _reader.ReadAsync(cancellationToken);
        }
    }
}
