using FsgImg.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces;

namespace FsgImg.Dds
{
    public class UncompressedDdsTexture : IDdsTexture, IUncompressedTexture
    {
        private readonly IUncompressedTexture _texture;

        public UncompressedDdsTexture(IUncompressedTexture texture)
        {
            _texture = texture;
        }

        public uint Pitch
        {
            get
            {
                return (Width * BitsPerPixel + 7) / 8;
            }
        }

        public uint BitsPerPixel
        {
            get
            {
                return _texture.BitsPerPixel;
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
