using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading.Tasks;

namespace FsgImg.IO
{
    public class ImgHeaderBufferWriter : IImgHeaderWriter
    {
        private readonly byte[] _buffer;
        private readonly int _offset, _count;

        public ImgHeaderBufferWriter(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public ImgHeaderBufferWriter(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public void Write(IImgHeader imgHeader)
        {
            var span = new Span<byte>(_buffer, _offset, _count);
            var options = new ImgHeaderOptions(imgHeader);
            var start = 0;

            EndianBinaryPrimitives.WriteUInt16(span.Slice(start += sizeof(ushort), sizeof(ushort)), imgHeader.Width, options.IsLittleEndian);
            EndianBinaryPrimitives.WriteUInt16(span.Slice(start += sizeof(ushort), sizeof(ushort)), imgHeader.Height, options.IsLittleEndian);
            EndianBinaryPrimitives.WriteUInt16(span.Slice(start += sizeof(ushort), sizeof(ushort)), imgHeader.Depth, options.IsLittleEndian);
            EndianBinaryPrimitives.WriteUInt16(span.Slice(start += sizeof(ushort), sizeof(ushort)), imgHeader.Pitch, options.IsLittleEndian);
            EndianBinaryPrimitives.WriteUInt32(span.Slice(start += sizeof(uint), sizeof(uint)), (uint)imgHeader.TextureFormat, options.IsLittleEndian);
            EndianBinaryPrimitives.WriteUInt16(span.Slice(start += sizeof(ushort), sizeof(ushort)), imgHeader.BcAlpha, options.IsLittleEndian);
            BinaryPrimitives.WriteUInt16BigEndian(span.Slice(start += sizeof(ushort), sizeof(ushort)), (ushort)imgHeader.Game);

            var mipmapCount = imgHeader.MipmapCount;
            if (options.IncludesBaseLevelMipmap)
            {
                // Substract base level mipmap
                mipmapCount -= 1;
            }
            EndianBinaryPrimitives.WriteUInt16(span.Slice(start += sizeof(ushort), sizeof(ushort)), mipmapCount, options.IsLittleEndian);

            BinaryPrimitives.WriteUInt16BigEndian(span.Slice(start += sizeof(ushort), sizeof(ushort)), (ushort)imgHeader.Platform);
        }

        public Task WriteAsync(IImgHeader imgHeader)
        {
            Write(imgHeader);
            return Task.CompletedTask;
        }
    }
}
