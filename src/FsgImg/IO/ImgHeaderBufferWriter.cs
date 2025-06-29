using FsgImg.Abstractions;
using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading;
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
            var options = new ImgHeaderOptions(imgHeader.Platform);

            EndianBinaryPrimitives.WriteUInt16(span.Slice(ImgConstants.WidthOffset, sizeof(ushort)), imgHeader.Width, options.IsLittleEndian);
            EndianBinaryPrimitives.WriteUInt16(span.Slice(ImgConstants.HeightOffset, sizeof(ushort)), imgHeader.Height, options.IsLittleEndian);
            EndianBinaryPrimitives.WriteUInt16(span.Slice(ImgConstants.DepthOffset, sizeof(ushort)), imgHeader.Depth, options.IsLittleEndian);
            EndianBinaryPrimitives.WriteUInt16(span.Slice(ImgConstants.PitchOffset, sizeof(ushort)), imgHeader.Pitch, options.IsLittleEndian);
            EndianBinaryPrimitives.WriteUInt32(span.Slice(ImgConstants.TextureFormatOffset, sizeof(uint)), (uint)imgHeader.TextureFormat, options.IsLittleEndian);
            EndianBinaryPrimitives.WriteUInt16(span.Slice(ImgConstants.BcAlphaOffset, sizeof(ushort)), imgHeader.BcAlpha, options.IsLittleEndian);
            BinaryPrimitives.WriteUInt16BigEndian(span.Slice(ImgConstants.GameOffset, sizeof(ushort)), (ushort)imgHeader.Game);

            var mipmapCount = imgHeader.MipmapCount;
            if (!options.IncludesBaseLevelMipmap)
            {
                // Substract base level mipmap
                mipmapCount -= 1;
            }
            EndianBinaryPrimitives.WriteUInt16(span.Slice(ImgConstants.MipmapCountOffset, sizeof(ushort)), mipmapCount, options.IsLittleEndian);

            BinaryPrimitives.WriteUInt16BigEndian(span.Slice(ImgConstants.PlatformOffset, sizeof(ushort)), (ushort)imgHeader.Platform);
        }

        public Task WriteAsync(IImgHeader imgHeader, CancellationToken cancellationToken = default)
        {
            Write(imgHeader);
            return Task.CompletedTask;
        }
    }
}
