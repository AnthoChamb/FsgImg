using FsgImg.Dds.Abstractions;
using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using System.IO;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsHeaderDxt10StreamWriter : IDdsHeaderDxt10Writer
    {
        private readonly Stream _stream;
        private readonly IDdsHeaderDxt10BufferWriterFactory _factory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsHeaderDxt10StreamWriter(Stream stream, IDdsHeaderDxt10BufferWriterFactory factory) : this(stream, factory, false)
        {
        }

        public DdsHeaderDxt10StreamWriter(Stream stream, IDdsHeaderDxt10BufferWriterFactory factory, bool leaveOpen)
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

        public void Write(IDdsHeaderDxt10 ddsHeaderDxt10)
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[DdsConstants.DdsHeaderDxt10Size];

            using (var writer = _factory.Create(buffer, 0, buffer.Length))
            {
                writer.Write(ddsHeaderDxt10);
            }

            _stream.Write(buffer, 0, buffer.Length);
        }

        public async Task WriteAsync(IDdsHeaderDxt10 ddsHeaderDxt10)
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[DdsConstants.DdsHeaderDxt10Size];

            using (var writer = _factory.Create(buffer, 0, buffer.Length))
            {
                await writer.WriteAsync(ddsHeaderDxt10);
            }

            await _stream.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
