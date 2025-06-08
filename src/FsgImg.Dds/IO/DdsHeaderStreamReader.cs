using FsgImg.Dds.Abstractions;
using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.IO.Extensions;
using System.IO;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsHeaderStreamReader : IDdsHeaderReader
    {
        private readonly Stream _stream;
        private readonly IDdsHeaderBufferReaderFactory _factory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsHeaderStreamReader(Stream stream, IDdsHeaderBufferReaderFactory factory) : this(stream, factory, false)
        {
        }

        public DdsHeaderStreamReader(Stream stream, IDdsHeaderBufferReaderFactory factory, bool leaveOpen)
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

        public IDdsHeader Read()
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[DdsConstants.DdsHeaderSize];
            _stream.ReadExactly(buffer, 0, DdsConstants.DdsHeaderSize);

            using (var reader = _factory.Create(buffer, 0, buffer.Length))
            {
                return reader.Read();
            }
        }

        public async Task<IDdsHeader> ReadAsync()
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[DdsConstants.DdsHeaderSize];
            await _stream.ReadExactlyAsync(buffer, 0, DdsConstants.DdsHeaderSize);

            using (var reader = _factory.Create(buffer, 0, buffer.Length))
            {
                return await reader.ReadAsync();
            }
        }
    }
}
