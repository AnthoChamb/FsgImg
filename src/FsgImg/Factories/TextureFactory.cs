using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.Factories;

namespace FsgImg.Factories
{
    public class TextureFactory : ITextureFactory
    {
        public IBlockCompressedTexture CreateBlockCompressedTexture(uint width, uint height, uint mipmapCount, uint blockWidth, uint blockHeight, uint blockSize)
        {
            return new BlockCompressedTexture(width, height, mipmapCount, blockWidth, blockHeight, blockSize);
        }

        public ITexture CreateUncompressedTexture(uint width, uint height, uint mipmapCount, uint bitsPerPixel)
        {
            return new UncompressedTexture(width, height, mipmapCount, bitsPerPixel);
        }
    }
}
