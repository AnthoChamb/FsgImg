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
    public class DdsHeaderDxt10StreamReader : IDdsHeaderDxt10Reader
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IDdsHeaderDxt10Reader _reader;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsHeaderDxt10StreamReader(Stream stream, IDdsHeaderDxt10ByteArrayReaderFactory factory) : this(stream, factory, false)
        {
        }

        public DdsHeaderDxt10StreamReader(Stream stream, IDdsHeaderDxt10ByteArrayReaderFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(DdsConstants.DdsHeaderDxt10Size);
            _reader = factory.Create(_buffer, 0, DdsConstants.DdsHeaderDxt10Size);
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

        public IDdsHeaderDxt10 Read()
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(DdsHeaderDxt10StreamReader).FullName);
            }

            _stream.ReadExactly(_buffer, 0, DdsConstants.DdsHeaderDxt10Size);

            return _reader.Read();
        }

        public async Task<IDdsHeaderDxt10> ReadAsync(CancellationToken cancellationToken = default)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(DdsHeaderDxt10StreamReader).FullName);
            }

            await _stream.ReadExactlyAsync(_buffer, 0, DdsConstants.DdsHeaderDxt10Size, cancellationToken);

            return await _reader.ReadAsync(cancellationToken);
        }
    }
}
