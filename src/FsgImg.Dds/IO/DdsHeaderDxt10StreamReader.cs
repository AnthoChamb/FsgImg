using FsgImg.Dds.Interfaces;
using FsgImg.Dds.Interfaces.Factories;
using FsgImg.Dds.Interfaces.IO;
using System.IO;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsHeaderDxt10StreamReader : IDdsHeaderDxt10Reader
    {
        private readonly Stream _stream;
        private readonly IDdsHeaderDxt10BufferReaderFactory _factory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsHeaderDxt10StreamReader(Stream stream, IDdsHeaderDxt10BufferReaderFactory factory) : this(stream, factory, false)
        {
        }

        public DdsHeaderDxt10StreamReader(Stream stream, IDdsHeaderDxt10BufferReaderFactory factory, bool leaveOpen)
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

        public IDdsHeaderDxt10 Read()
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[DdsConstants.DdsHeaderDxt10Size];
            // TODO: Use ReadExactly when available
            var bytesRead = _stream.Read(buffer, 0, buffer.Length);

            if (bytesRead != buffer.Length)
            {
                throw new EndOfStreamException();
            }

            using (var reader = _factory.Create(buffer, 0, buffer.Length))
            {
                return reader.Read();
            }
        }

        public async Task<IDdsHeaderDxt10> ReadAsync()
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[DdsConstants.DdsHeaderDxt10Size];
            // TODO: Use ReadExactlyAsync when available
            var bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);

            if (bytesRead != buffer.Length)
            {
                throw new EndOfStreamException();
            }

            using (var reader = _factory.Create(buffer, 0, buffer.Length))
            {
                return await reader.ReadAsync();
            }
        }
    }
}
