using FsgImg.Dds.Interfaces;
using FsgImg.Dds.Interfaces.Factories;
using FsgImg.Dds.Interfaces.IO;
using System.Buffers.Binary;
using System.IO;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsFileStreamWriter : IDdsFileWriter
    {
        private readonly Stream _stream;
        private readonly IDdsHeaderStreamWriterFactory _headerWriterFactory;
        private readonly IDdsHeaderDxt10StreamWriterFactory _headerDxt10WriterFactory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsFileStreamWriter(Stream stream, IDdsHeaderStreamWriterFactory headerWriterFactory, IDdsHeaderDxt10StreamWriterFactory headerDxt10WriterFactory)
            : this(stream, headerWriterFactory, headerDxt10WriterFactory, false)
        {
        }

        public DdsFileStreamWriter(Stream stream, IDdsHeaderStreamWriterFactory headerWriterFactory, IDdsHeaderDxt10StreamWriterFactory headerDxt10WriterFactory, bool leaveOpen)
        {
            _stream = stream;
            _headerWriterFactory = headerWriterFactory;
            _headerDxt10WriterFactory = headerDxt10WriterFactory;
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

        public void Write(IDdsFile ddsFile)
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[sizeof(uint)];

            BinaryPrimitives.WriteUInt32LittleEndian(buffer, ddsFile.Magic);

            _stream.Write(buffer, 0, buffer.Length);

            using (var headerWriter = _headerWriterFactory.Create(_stream, true))
            {
                headerWriter.Write(ddsFile.Header);
            }

            if (ddsFile.HeaderDxt10 != null)
            {
                using (var headerDxt10Writer = _headerDxt10WriterFactory.Create(_stream, true))
                {
                    headerDxt10Writer.Write(ddsFile.HeaderDxt10);
                }
            }
        }

        public async Task WriteAsync(IDdsFile ddsFile)
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[sizeof(uint)];

            BinaryPrimitives.WriteUInt32LittleEndian(buffer, ddsFile.Magic);

            await _stream.WriteAsync(buffer, 0, buffer.Length);

            using (var headerWriter = _headerWriterFactory.Create(_stream, true))
            {
                await headerWriter.WriteAsync(ddsFile.Header);
            }

            if (ddsFile.HeaderDxt10 != null)
            {
                using (var headerDxt10Writer = _headerDxt10WriterFactory.Create(_stream, true))
                {
                    await headerDxt10Writer.WriteAsync(ddsFile.HeaderDxt10);
                }
            }
        }
    }
}
