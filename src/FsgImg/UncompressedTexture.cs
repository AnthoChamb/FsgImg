using FsgImg.Abstractions.Interfaces;

namespace FsgImg
{
    public class UncompressedTexture : Texture, IUncompressedTexture
    {
        public UncompressedTexture(uint width, uint height, uint mipmapCount, uint bitsPerPixel)
            : base(width, height, mipmapCount)
        {
            BitsPerPixel = bitsPerPixel;
        }

        public uint BitsPerPixel { get; }

        public override bool IsUncompressed { get; } = true;

        protected override uint GetMipmapSize(uint width, uint height)
        {
            return Width * Height * (BitsPerPixel / 8);
        }
    }
}
