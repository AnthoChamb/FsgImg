using FsgImg.Abstractions;
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
            imgHeader.Platform = (ImgPlatform)BinaryPrimitives.ReadUInt16BigEndian(span.Slice(ImgConstants.PlatformOffset, sizeof(ushort)));

            var options = new ImgHeaderOptions(imgHeader);

            imgHeader.Width = EndianBinaryPrimitives.ReadUInt16(span.Slice(ImgConstants.WidthOffset, sizeof(ushort)), options.IsLittleEndian);
            imgHeader.Height = EndianBinaryPrimitives.ReadUInt16(span.Slice(ImgConstants.HeightOffset, sizeof(ushort)), options.IsLittleEndian);
            imgHeader.Depth = EndianBinaryPrimitives.ReadUInt16(span.Slice(ImgConstants.DepthOffset, sizeof(ushort)), options.IsLittleEndian);
            imgHeader.Pitch = EndianBinaryPrimitives.ReadUInt16(span.Slice(ImgConstants.PitchOffset, sizeof(ushort)), options.IsLittleEndian);
            imgHeader.TextureFormat = (ImgTextureFormat)EndianBinaryPrimitives.ReadUInt32(span.Slice(ImgConstants.TextureFormatOffset, sizeof(uint)), options.IsLittleEndian);
            imgHeader.BcAlpha = EndianBinaryPrimitives.ReadUInt16(span.Slice(ImgConstants.BcAlphaOffset, sizeof(ushort)), options.IsLittleEndian);
            imgHeader.Game = (ImgGame)BinaryPrimitives.ReadUInt16BigEndian(span.Slice(ImgConstants.GameOffset, sizeof(ushort)));

            var mipmapCount = EndianBinaryPrimitives.ReadUInt16(span.Slice(ImgConstants.MipmapCountOffset, sizeof(ushort)), options.IsLittleEndian);
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
