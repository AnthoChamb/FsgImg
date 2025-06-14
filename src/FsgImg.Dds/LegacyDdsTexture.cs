using FsgImg.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces;

namespace FsgImg.Dds
{
    public class LegacyDdsTexture : IDdsTexture
    {
        private readonly ITexture _texture;

        public LegacyDdsTexture(ITexture texture)
        {
            _texture = texture;
        }

        public uint Pitch
        {
            get
            {
                return ((Width + 1) >> 1) * 4;
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
