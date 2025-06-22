using FsgImg.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces;

namespace FsgImg.Dds
{
    public class DdsTexture : IDdsTexture
    {
        private readonly ITexture _texture;

        public DdsTexture(ITexture texture)
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
