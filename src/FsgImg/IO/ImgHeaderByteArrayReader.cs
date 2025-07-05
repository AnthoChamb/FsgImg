using FsgImg.Abstractions;
using FsgImg.Abstractions.Enums;
using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.IO
{
    public class ImgHeaderByteArrayReader : IImgHeaderReader
    {
        private readonly IImgHeaderFactory _factory;
        private readonly byte[] _buffer;
        private readonly int _offset, _count;

        public ImgHeaderByteArrayReader(IImgHeaderFactory factory, byte[] buffer) : this(factory, buffer, 0, buffer.Length)
        {
        }

        public ImgHeaderByteArrayReader(IImgHeaderFactory factory, byte[] buffer, int offset, int count)
        {
            _factory = factory;
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

            var platform = (ImgPlatform)BinaryPrimitives.ReadUInt16BigEndian(span.Slice(ImgConstants.PlatformOffset, sizeof(ushort)));

            var options = new ImgHeaderOptions(platform);

            var width = EndianBinaryPrimitives.ReadUInt16(span.Slice(ImgConstants.WidthOffset, sizeof(ushort)), options.IsLittleEndian);
            var height = EndianBinaryPrimitives.ReadUInt16(span.Slice(ImgConstants.HeightOffset, sizeof(ushort)), options.IsLittleEndian);
            var depth = EndianBinaryPrimitives.ReadUInt16(span.Slice(ImgConstants.DepthOffset, sizeof(ushort)), options.IsLittleEndian);
            var pitch = EndianBinaryPrimitives.ReadUInt16(span.Slice(ImgConstants.PitchOffset, sizeof(ushort)), options.IsLittleEndian);
            var textureFormat = (ImgTextureFormat)EndianBinaryPrimitives.ReadUInt32(span.Slice(ImgConstants.TextureFormatOffset, sizeof(uint)), options.IsLittleEndian);
            var bcAlpha = EndianBinaryPrimitives.ReadUInt16(span.Slice(ImgConstants.BcAlphaOffset, sizeof(ushort)), options.IsLittleEndian);
            var game = (ImgGame)BinaryPrimitives.ReadUInt16BigEndian(span.Slice(ImgConstants.GameOffset, sizeof(ushort)));

            var mipmapCount = EndianBinaryPrimitives.ReadUInt16(span.Slice(ImgConstants.MipmapCountOffset, sizeof(ushort)), options.IsLittleEndian);
            if (!options.IncludesBaseLevelMipmap)
            {
                // Add base level mipmap
                mipmapCount += 1;
            }

            return _factory.Create(width, height, depth, pitch, textureFormat, bcAlpha, game, mipmapCount, platform);
        }

        public Task<IImgHeader> ReadAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Read());
        }
    }
}
