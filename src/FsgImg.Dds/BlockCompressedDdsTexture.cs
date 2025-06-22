using FsgImg.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces;
using System;

namespace FsgImg.Dds
{
    public class BlockCompressedDdsTexture : IDdsTexture, IBlockCompressedTexture
    {
        private readonly IBlockCompressedTexture _texture;

        public BlockCompressedDdsTexture(IBlockCompressedTexture texture)
        {
            _texture = texture;
        }

        public uint Pitch
        {
            get
            {
                return Math.Max(1, (Width + 3) / 4) * BlockSize;
            }
        }

        public uint BlockWidth
        {
            get
            {
                return _texture.BlockWidth;
            }
        }

        public uint BlockHeight
        {
            get
            {
                return _texture.BlockHeight;
            }
        }

        public uint BlockSize
        {
            get
            {
                return _texture.BlockSize;
            }
        }

        public uint Width
        {
            get
            {
                return _texture.Width;
            }
        }

        public uint Height
        {
            get
            {
                return _texture.Height;
            }
        }

        public uint MipmapCount
        {
            get
            {
                return _texture.MipmapCount;
            }
        }

        public uint BitsPerPixel
        {
            get
            {
                return _texture.BitsPerPixel;
            }
        }

        public uint Size
        {
            get
            {
                return _texture.Size;
            }
        }

        public bool IsUncompressed
        {
            get
            {
                return _texture.IsUncompressed;
            }
        }
    }
}
