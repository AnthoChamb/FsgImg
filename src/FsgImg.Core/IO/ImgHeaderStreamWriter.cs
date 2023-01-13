using FsgImg.Core.Interfaces;
using FsgImg.Core.Interfaces.Factories;
using FsgImg.Core.Interfaces.IO;
using System.IO;
using System.Threading.Tasks;

namespace FsgImg.Core.IO
{
    public class ImgHeaderStreamWriter : IImgHeaderWriter
    {
        private readonly Stream _stream;
        private readonly IImgHeaderBufferWriterFactory _factory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public ImgHeaderStreamWriter(Stream stream, IImgHeaderBufferWriterFactory factory) : this(stream, factory, false)
        {
        }

        public ImgHeaderStreamWriter(Stream stream, IImgHeaderBufferWriterFactory factory, bool leaveOpen)
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

        public async Task WriteAsync(IImgHeader imgHeader)
        {
            // TODO: Use ArrayPool when available
            var buffer = new byte[20];

            using (var writer = _factory.Create(buffer, 0, buffer.Length))
            {
                await writer.WriteAsync(imgHeader);
            }

            await _stream.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
