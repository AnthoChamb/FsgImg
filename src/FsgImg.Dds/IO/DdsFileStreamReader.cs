using FsgImg.Dds.Enums;
using FsgImg.Dds.Exceptions;
using FsgImg.Dds.Interfaces;
using FsgImg.Dds.Interfaces.Factories;
using FsgImg.Dds.Interfaces.IO;
using System.Buffers.Binary;
using System.IO;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsFileStreamReader : IDdsFileReader
    {
        private readonly Stream _stream;
        private readonly IDdsHeaderStreamReaderFactory _headerReaderFactory;
        private readonly IDdsHeaderDxt10StreamReaderFactory _headerDxt10ReaderFactory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsFileStreamReader(Stream stream, IDdsHeaderStreamReaderFactory headerReaderFactory, IDdsHeaderDxt10StreamReaderFactory headerDxt10ReaderFactory)
            : this(stream, headerReaderFactory, headerDxt10ReaderFactory, false)
        {
        }

        public DdsFileStreamReader(Stream stream, IDdsHeaderStreamReaderFactory headerReaderFactory, IDdsHeaderDxt10StreamReaderFactory headerDxt10ReaderFactory, bool leaveOpen)
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

        public IDdsFile Read()
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[sizeof(uint)];
            // TODO: Use ReadExactly when available
            var bytesRead = _stream.Read(buffer, 0, buffer.Length);

            if (bytesRead != buffer.Length)
            {
                throw new EndOfStreamException();
            }

            var magic = BinaryPrimitives.ReadUInt32LittleEndian(buffer);
            if (magic != DdsConstants.DdsFileMagic)
            {
                throw new InvalidDdsFileMagicException(magic);
            }

            var ddsFile = new DdsFile();
            ddsFile.Magic = magic;

            using (var headerReader = _headerReaderFactory.Create(_stream, true))
            {
                ddsFile.Header = headerReader.Read();
            }

            if (ddsFile.Header.PixelFormat.FourCc == DdsFourCc.Dx10)
            {
                using (var headerDxt10Reader = _headerDxt10ReaderFactory.Create(_stream, true))
                {
                    ddsFile.HeaderDxt10 = headerDxt10Reader.Read();
                }
            }

            return ddsFile;
        }

        public async Task<IDdsFile> ReadAsync()
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[sizeof(uint)];
            // TODO: Use ReadExactlyAsync when available
            var bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);

            if (bytesRead != buffer.Length)
            {
                throw new EndOfStreamException();
            }

            var magic = BinaryPrimitives.ReadUInt32LittleEndian(buffer);
            if (magic != DdsConstants.DdsFileMagic)
            {
                throw new InvalidDdsFileMagicException(magic);
            }

            var ddsFile = new DdsFile();
            ddsFile.Magic = magic;

            using (var headerReader = _headerReaderFactory.Create(_stream, true))
            {
                ddsFile.Header = await headerReader.ReadAsync();
            }

            if (ddsFile.Header.PixelFormat.FourCc == DdsFourCc.Dx10)
            {
                using (var headerDxt10Reader = _headerDxt10ReaderFactory.Create(_stream, true))
                {
                    ddsFile.HeaderDxt10 = await headerDxt10Reader.ReadAsync();
                }
            }

            return ddsFile;
        }
    }
}
