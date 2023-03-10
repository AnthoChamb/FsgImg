using FsgImg.Core.Interfaces;
using FsgImg.Core.Interfaces.IO;
using FsgImg.IO;
using System;
using System.Buffers.Binary;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FsgImg.Core.IO
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
            EndianBinaryPrimitives.WriteUInt16(span.Slice(start += sizeof(ushort), sizeof(ushort)), imgHeader.Width, options.IsLittleEndian);

            ushort unk = 0x00_00;
            MemoryMarshal.Write(span.Slice(start += sizeof(ushort), sizeof(ushort)), ref unk);

            BinaryPrimitives.WriteUInt32BigEndian(span.Slice(start += sizeof(uint), sizeof(uint)), (uint)imgHeader.TextureFormat);
            BinaryPrimitives.WriteUInt16BigEndian(span.Slice(start += sizeof(ushort), sizeof(ushort)), (ushort)imgHeader.Game);

            var mipmapCount = imgHeader.MipmapCount;
            EndianBinaryPrimitives.WriteUInt16(span.Slice(start += sizeof(ushort), sizeof(ushort)), (ushort)(options.IncludesBaseLevelMipmap ? mipmapCount : mipmapCount - 1), options.IsLittleEndian);
            BinaryPrimitives.WriteUInt16BigEndian(span.Slice(start += sizeof(ushort), sizeof(ushort)), (ushort)imgHeader.Platform);
        }

        public Task WriteAsync(IImgHeader imgHeader)
        {
            Write(imgHeader);
            return Task.CompletedTask;
        }
    }
}
