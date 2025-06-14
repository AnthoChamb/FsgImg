using FsgImg.Abstractions.Interfaces;

namespace FsgImg
{
    public abstract class Texture : ITexture
    {
        public Texture(uint width, uint height, uint mipmapCount)
        {
            Width = width;
            Height = height;
            MipmapCount = mipmapCount;
        }

        public uint Width { get; }
        public uint Height { get; }
        public uint MipmapCount { get; }

        public uint Size
        {
            get
            {
                uint size = 0;
                var width = Width;
                var height = Height;

                for (var i = 0; i < MipmapCount; i++)
                {
                    size += GetMipmapSize(width, height);
                    width /= 2;
                    height /= 2;
                }

                return size;
            }
        }

        public abstract bool IsUncompressed { get; }

        protected abstract uint GetMipmapSize(uint width, uint height);
    }
}
