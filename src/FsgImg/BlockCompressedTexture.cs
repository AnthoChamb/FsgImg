using FsgImg.Abstractions.Interfaces;
using System;

namespace FsgImg
{
    public class BlockCompressedTexture : Texture, IBlockCompressedTexture
    {
        public BlockCompressedTexture(uint width,
                                      uint height,
                                      uint mipmapCount,
                                      uint blockWidth,
                                      uint blockHeight,
                                      uint blockSize)
            : base(width, height, mipmapCount)
        {
            BlockWidth = blockWidth;
            BlockHeight = blockHeight;
            BlockSize = blockSize;
        }

        public uint BlockWidth { get; }
        public uint BlockHeight { get; }
        public uint BlockSize { get; }

        public override uint BitsPerPixel
        {
            get
            {
                return BlockSize * 8 / BlockWidth / BlockHeight;
            }
        }

        public override bool IsUncompressed { get; } = false;

        protected override uint GetMipmapSize(uint width, uint height)
        {
            return Math.Max(1, (width + BlockWidth - 1) / BlockWidth) * Math.Max(1, (height + BlockHeight - 1) / BlockHeight) * BlockSize;
        }
    }
}
