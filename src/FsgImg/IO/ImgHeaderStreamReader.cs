using FsgImg.Abstractions;
using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Abstractions.Interfaces.IO;
using System.IO;
using System.Threading.Tasks;

namespace FsgImg.IO
{
    public class ImgHeaderStreamReader : IImgHeaderReader
    {
        private readonly Stream _stream;
        private readonly IImgHeaderBufferReaderFactory _factory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public ImgHeaderStreamReader(Stream stream, IImgHeaderBufferReaderFactory factory) : this(stream, factory, false)
        {
        }

        public ImgHeaderStreamReader(Stream stream, IImgHeaderBufferReaderFactory factory, bool leaveOpen)
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

        public IImgHeader Read()
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[ImgConstants.ImgHeaderSize];
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

        public async Task<IImgHeader> ReadAsync()
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[ImgConstants.ImgHeaderSize];
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
