using FsgImg.Dds.Abstractions.Enums;
using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.Exceptions;
using FsgImg.IO.Extensions;
using System.Buffers;
using System.Buffers.Binary;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsStreamReader : IDdsReader
    {
        private readonly Stream _stream;
        private readonly IDdsHeaderStreamReaderFactory _headerReaderFactory;
        private readonly IDdsHeaderDxt10StreamReaderFactory _headerDxt10ReaderFactory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsStreamReader(Stream stream, IDdsHeaderStreamReaderFactory headerReaderFactory, IDdsHeaderDxt10StreamReaderFactory headerDxt10ReaderFactory)
            : this(stream, headerReaderFactory, headerDxt10ReaderFactory, false)
        {
        }

        public DdsStreamReader(Stream stream, IDdsHeaderStreamReaderFactory headerReaderFactory, IDdsHeaderDxt10StreamReaderFactory headerDxt10ReaderFactory, bool leaveOpen)
        {
            _stream = stream;
            _headerReaderFactory = headerReaderFactory;
            _headerDxt10ReaderFactory = headerDxt10ReaderFactory;
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
                _disposed = true;
            }
        }

        public IDds Read()
        {
            uint magic;
            var buffer = ArrayPool<byte>.Shared.Rent(sizeof(uint));
            try
            {
                _stream.ReadExactly(buffer, 0, sizeof(uint));
                magic = BinaryPrimitives.ReadUInt32LittleEndian(buffer);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }

            InvalidDdsMagicException.ThrowIfInvalid(magic);

            var dds = new Dds();
            dds.Magic = magic;

            using (var headerReader = _headerReaderFactory.Create(_stream, true))
            {
                dds.Header = headerReader.Read();
            }

            if (dds.Header.PixelFormat.FourCc == DdsFourCc.Dx10)
            {
                using (var headerDxt10Reader = _headerDxt10ReaderFactory.Create(_stream, true))
                {
                    dds.HeaderDxt10 = headerDxt10Reader.Read();
                }
            }

            return dds;
        }

        public async Task<IDds> ReadAsync(CancellationToken cancellationToken = default)
        {
            uint magic;
            var buffer = ArrayPool<byte>.Shared.Rent(sizeof(uint));
            try
            {
                await _stream.ReadExactlyAsync(buffer, 0, sizeof(uint), cancellationToken);
                magic = BinaryPrimitives.ReadUInt32LittleEndian(buffer);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }

            InvalidDdsMagicException.ThrowIfInvalid(magic);

            var dds = new Dds();
            dds.Magic = magic;

            using (var headerReader = _headerReaderFactory.Create(_stream, true))
            {
                dds.Header = await headerReader.ReadAsync(cancellationToken);
            }

            if (dds.Header.PixelFormat.FourCc == DdsFourCc.Dx10)
            {
                using (var headerDxt10Reader = _headerDxt10ReaderFactory.Create(_stream, true))
                {
                    dds.HeaderDxt10 = await headerDxt10Reader.ReadAsync(cancellationToken);
                }
            }

            return dds;
        }
    }
}
