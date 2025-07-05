using CommunityToolkit.Diagnostics;
using FsgImg.IO.Extensions;
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
    public class PvrHeaderStreamReader : IPvrHeaderReader
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IPvrHeaderReader _reader;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public PvrHeaderStreamReader(Stream stream, IPvrHeaderByteArrayReaderFactory factory) : this(stream, factory, false)
        {
        }

        public PvrHeaderStreamReader(Stream stream, IPvrHeaderByteArrayReaderFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(PvrConstants.PvrHeaderSize);
            _reader = factory.Create(_buffer, 0, PvrConstants.PvrHeaderSize);
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

        public IPvrHeader Read()
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(PvrHeaderStreamReader).FullName);
            }

            _stream.ReadExactly(_buffer, 0, PvrConstants.PvrHeaderSize);

            return _reader.Read();
        }

        public async Task<IPvrHeader> ReadAsync(CancellationToken cancellationToken = default)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(PvrHeaderStreamReader).FullName);
            }

            await _stream.ReadExactlyAsync(_buffer, 0, PvrConstants.PvrHeaderSize, cancellationToken);

            return await _reader.ReadAsync(cancellationToken);
        }
    }
}
