using FsgImg.Abstractions.Enums;
using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading.Tasks;

namespace FsgImg.IO
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

        public IImgHeader Read()
        {
            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count);

            var imgHeader = new ImgHeader();
            imgHeader.Game = (ImgGame)BinaryPrimitives.ReadUInt16BigEndian(span.Slice(14, sizeof(ushort)));

            var textureFormat = BinaryPrimitives.ReadUInt32BigEndian(span.Slice(10, sizeof(uint)));
            if (imgHeader.Game == ImgGame.Djh)
            {
                // Djh texture format values may only be on two bytes
                switch (textureFormat & 0xFF_FF_00_00u)
                {
                    case (uint)ImgTextureFormat.DdsDxt3 & 0xFF_FF_00_00u:
                        textureFormat = (uint)ImgTextureFormat.DdsDxt3;
                        break;
                    case (uint)ImgTextureFormat.DdsDxt5 & 0xFF_FF_00_00u:
                        textureFormat = (uint)ImgTextureFormat.DdsDxt5;
                        break;
                }
            }

            imgHeader.TextureFormat = (ImgTextureFormat)textureFormat;
            imgHeader.Platform = (ImgPlatform)BinaryPrimitives.ReadUInt16BigEndian(span.Slice(18, sizeof(ushort)));

            var options = new ImgHeaderOptions(imgHeader);

            imgHeader.Width = EndianBinaryPrimitives.ReadUInt16(span.Slice(0, sizeof(ushort)), options.IsLittleEndian);
            imgHeader.Height = EndianBinaryPrimitives.ReadUInt16(span.Slice(2, sizeof(ushort)), options.IsLittleEndian);
            imgHeader.Depth = EndianBinaryPrimitives.ReadUInt16(span.Slice(4, sizeof(ushort)), options.IsLittleEndian);

            var mipmapCount = EndianBinaryPrimitives.ReadUInt16(span.Slice(6, sizeof(ushort)), options.IsLittleEndian);
            if (!options.IncludesBaseLevelMipmap)
            {
                // Add base level mipmap
                mipmapCount += 1;
            }
            imgHeader.MipmapCount = mipmapCount;

            return imgHeader;
        }

        public Task<IImgHeader> ReadAsync()
        {
            return Task.FromResult(Read());
        }
    }
}
