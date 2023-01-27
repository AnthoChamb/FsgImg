using FsgImg.Dds.Interfaces;
using FsgImg.Dds.Interfaces.Factories;
using FsgImg.Dds.Interfaces.IO;
using System.IO;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsHeaderStreamWriter : IDdsHeaderWriter
    {
        private readonly Stream _stream;
        private readonly IDdsHeaderBufferWriterFactory _factory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsHeaderStreamWriter(Stream stream, IDdsHeaderBufferWriterFactory factory) : this(stream, factory, false)
        {
        }

        public DdsHeaderStreamWriter(Stream stream, IDdsHeaderBufferWriterFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _factory = factory;
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

        public void Write(IDdsHeader ddsHeader)
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[DdsConstants.DdsHeaderSize];

            using (var writer = _factory.Create(buffer, 0, buffer.Length))
            {
                writer.Write(ddsHeader);
            }

            _stream.Write(buffer, 0, buffer.Length);
        }

        public async Task WriteAsync(IDdsHeader ddsHeader)
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[DdsConstants.DdsHeaderSize];

            using (var writer = _factory.Create(buffer, 0, buffer.Length))
            {
                await writer.WriteAsync(ddsHeader);
            }

            await _stream.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
