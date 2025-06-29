namespace FsgImg.Abstractions.Interfaces.Factories
{
    public interface ITextureFactory
    {
        IBlockCompressedTexture CreateBlockCompressedTexture(uint width,
                                                             uint height,
                                                             uint mipmapCount,
                                                             uint blockWidth,
                                                             uint blockHeight,
                                                             uint blockSize);
        ITexture CreateUncompressedTexture(uint width, uint height, uint mipmapCount, uint bitsPerPixel);
    }
}
