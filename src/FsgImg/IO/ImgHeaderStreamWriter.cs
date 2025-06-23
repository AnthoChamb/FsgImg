using CommunityToolkit.Diagnostics;
using FsgImg.Abstractions;
using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Abstractions.Interfaces.IO;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.IO
{
    public class ImgHeaderStreamWriter : IImgHeaderWriter
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IImgHeaderWriter _writer;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public ImgHeaderStreamWriter(Stream stream, IImgHeaderBufferWriterFactory factory) : this(stream, factory, false)
        {
        }

        public ImgHeaderStreamWriter(Stream stream, IImgHeaderBufferWriterFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(ImgConstants.ImgHeaderSize);
            _writer = factory.Create(_buffer, 0, ImgConstants.ImgHeaderSize);
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
                ArrayPool<byte>.Shared.Return(_buffer);
                _writer.Dispose();
                _disposed = true;
            }
        }

        public void Write(IImgHeader imgHeader)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(ImgHeaderStreamWriter).FullName);
            }

            _writer.Write(imgHeader);

            _stream.Write(_buffer, 0, ImgConstants.ImgHeaderSize);
        }

        public async Task WriteAsync(IImgHeader imgHeader, CancellationToken cancellationToken = default)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(ImgHeaderStreamWriter).FullName);
            }

            await _writer.WriteAsync(imgHeader, cancellationToken);

            await _stream.WriteAsync(_buffer, 0, ImgConstants.ImgHeaderSize, cancellationToken);
        }
    }
}
