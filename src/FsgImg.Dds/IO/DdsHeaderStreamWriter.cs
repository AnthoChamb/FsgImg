using CommunityToolkit.Diagnostics;
using FsgImg.Dds.Abstractions;
using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using System.Buffers;
using System.IO;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsHeaderStreamWriter : IDdsHeaderWriter
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IDdsHeaderWriter _writer;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public DdsHeaderStreamWriter(Stream stream, IDdsHeaderBufferWriterFactory factory) : this(stream, factory, false)
        {
        }

        public DdsHeaderStreamWriter(Stream stream, IDdsHeaderBufferWriterFactory factory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(DdsConstants.DdsHeaderSize);
            _writer = factory.Create(_buffer, 0, DdsConstants.DdsHeaderSize);
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

        public void Write(IDdsHeader ddsHeader)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(DdsHeaderStreamWriter).FullName);
            }

            _writer.Write(ddsHeader);

            _stream.Write(_buffer, 0, DdsConstants.DdsHeaderSize);
        }

        public async Task WriteAsync(IDdsHeader ddsHeader)
        {
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(DdsHeaderStreamWriter).FullName);
            }

            await _writer.WriteAsync(ddsHeader);

            await _stream.WriteAsync(_buffer, 0, DdsConstants.DdsHeaderSize);
        }
    }
}
