using FsgImg.Dds.Abstractions;
using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsHeaderBufferWriter : IDdsHeaderWriter
    {
        private readonly byte[] _buffer;
        private readonly IDdsPixelFormatBufferWriterFactory _factory;
        private readonly int _offset, _count;

        public DdsHeaderBufferWriter(byte[] buffer, IDdsPixelFormatBufferWriterFactory factory) : this(buffer, factory, 0, buffer.Length)
        {
        }

        public DdsHeaderBufferWriter(byte[] buffer, IDdsPixelFormatBufferWriterFactory factory, int offset, int count)
        {
            _buffer = buffer;
            _factory = factory;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public void Write(IDdsHeader ddsHeader)
        {
            var span = new Span<byte>(_buffer, _offset, _count);
            var start = 0;

            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsHeader.Size);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), (uint)ddsHeader.Flags);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsHeader.Height);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsHeader.Width);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsHeader.PitchOrLinearSize);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsHeader.Depth);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsHeader.MipmapCount);

            foreach (var reserved in ddsHeader.Reserved)
            {
                BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), reserved);
            }

            using (var ddsPixelFormatWriter = _factory.Create(_buffer, start += DdsConstants.DdsPixelFormatSize, DdsConstants.DdsPixelFormatSize))
            {
                ddsPixelFormatWriter.Write(ddsHeader.PixelFormat);
            }

            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), (uint)ddsHeader.Caps);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), (uint)ddsHeader.Caps2);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsHeader.Caps3);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsHeader.Caps4);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsHeader.Reserved2);
        }

        public Task WriteAsync(IDdsHeader ddsHeader)
        {
            Write(ddsHeader);
            return Task.CompletedTask;
        }
    }
}
