using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using System.Buffers;
using System.Buffers.Binary;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsStreamWriter : IDdsWriter
    {
        private readonly Stream _stream;
        private readonly IDdsHeaderStreamWriterFactory _headerWriterFactory;
        private readonly IDdsHeaderDxt10StreamWriterFactory _headerDxt10WriterFactory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsStreamWriter(Stream stream, IDdsHeaderStreamWriterFactory headerWriterFactory, IDdsHeaderDxt10StreamWriterFactory headerDxt10WriterFactory)
            : this(stream, headerWriterFactory, headerDxt10WriterFactory, false)
        {
        }

        public DdsStreamWriter(Stream stream, IDdsHeaderStreamWriterFactory headerWriterFactory, IDdsHeaderDxt10StreamWriterFactory headerDxt10WriterFactory, bool leaveOpen)
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

        public void Write(IDds dds)
        {
            var buffer = ArrayPool<byte>.Shared.Rent(sizeof(uint));
            try
            {
                BinaryPrimitives.WriteUInt32LittleEndian(buffer, dds.Magic);
                _stream.Write(buffer, 0, sizeof(uint));
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }

            using (var headerWriter = _headerWriterFactory.Create(_stream, true))
            {
                headerWriter.Write(dds.Header);
            }

            if (dds.HeaderDxt10 != null)
            {
                using (var headerDxt10Writer = _headerDxt10WriterFactory.Create(_stream, true))
                {
                    headerDxt10Writer.Write(dds.HeaderDxt10);
                }
            }
        }

        public async Task WriteAsync(IDds dds, CancellationToken cancellationToken = default)
        {
            var buffer = ArrayPool<byte>.Shared.Rent(sizeof(uint));
            try
            {
                BinaryPrimitives.WriteUInt32LittleEndian(buffer, dds.Magic);
                await _stream.WriteAsync(buffer, 0, sizeof(uint), cancellationToken);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }

            using (var headerWriter = _headerWriterFactory.Create(_stream, true))
            {
                await headerWriter.WriteAsync(dds.Header, cancellationToken);
            }

            if (dds.HeaderDxt10 != null)
            {
                using (var headerDxt10Writer = _headerDxt10WriterFactory.Create(_stream, true))
                {
                    await headerDxt10Writer.WriteAsync(dds.HeaderDxt10, cancellationToken);
                }
            }
        }
    }
}
