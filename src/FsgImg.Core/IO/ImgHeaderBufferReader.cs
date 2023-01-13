using FsgImg.Core.Enums;
using FsgImg.Core.Interfaces;
using FsgImg.Core.Interfaces.IO;
using FsgImg.IO;
using System;
using System.Buffers.Binary;
using System.Threading.Tasks;

namespace FsgImg.Core.IO
{
    public class ImgHeaderBufferReader : IImgHeaderReader
    {
        private readonly byte[] _buffer;
        private readonly int _offset, _count;

        public ImgHeaderBufferReader(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public ImgHeaderBufferReader(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public Task<IImgHeader> ReadAsync()
        {
            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count);

            IImgHeader imgHeader = new ImgHeader();
            imgHeader.TextureFormat = (ImgTextureFormat)BinaryPrimitives.ReadUInt32BigEndian(span.Slice(10, sizeof(uint)));
            imgHeader.Game = (ImgGame)BinaryPrimitives.ReadUInt16BigEndian(span.Slice(14, sizeof(ushort)));
            imgHeader.Platform = (ImgPlatform)BinaryPrimitives.ReadUInt16BigEndian(span.Slice(18, sizeof(ushort)));

            var options = new ImgOptions(imgHeader);

            imgHeader.Width = EndianBinaryPrimitives.ReadUInt16(span.Slice(0, sizeof(ushort)), options.IsLittleEndian);
            imgHeader.Height = EndianBinaryPrimitives.ReadUInt16(span.Slice(2, sizeof(ushort)), options.IsLittleEndian);
            imgHeader.Depth = EndianBinaryPrimitives.ReadUInt16(span.Slice(4, sizeof(ushort)), options.IsLittleEndian);

            var mipmapCount = EndianBinaryPrimitives.ReadUInt16(span.Slice(6, sizeof(ushort)), options.IsLittleEndian);
            if (!options.IncludeBaseLevelMipmap)
            {
                // Add base level mipmap
                mipmapCount += 1;
            }
            imgHeader.MipmapCount = mipmapCount;

            return Task.FromResult(imgHeader);
        }
    }
}
