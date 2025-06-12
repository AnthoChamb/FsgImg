using CommunityToolkit.Diagnostics;
using FsgImg.Abstractions;
using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Abstractions.Interfaces.IO;
using FsgImg.IO.Extensions;
using System.Buffers;
using System.IO;
using System.Threading.Tasks;

namespace FsgImg.IO
{
    public class ImgHeaderStreamReader : IImgHeaderReader
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IImgHeaderReader _reader;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public ImgHeaderStreamReader(Stream stream, IImgHeaderBufferReaderFactory factory) : this(stream, factory, false)
        {
        }

        public ImgHeaderStreamReader(Stream stream, IImgHeaderBufferReaderFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(ImgConstants.ImgHeaderSize);
            _reader = factory.Create(_buffer, 0, ImgConstants.ImgHeaderSize);
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
                _reader.Dispose();
                _disposed = true;
            }
        }

        public IImgHeader Read()
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(ImgHeaderStreamReader).FullName);
            }

            _stream.ReadExactly(_buffer, 0, ImgConstants.ImgHeaderSize);

            return _reader.Read();
        }

        public async Task<IImgHeader> ReadAsync()
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(ImgHeaderStreamReader).FullName);
            }

            await _stream.ReadExactlyAsync(_buffer, 0, ImgConstants.ImgHeaderSize);

            return await _reader.ReadAsync();
        }
    }
}
