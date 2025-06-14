namespace FsgImg.Abstractions.Interfaces
{
    public interface IBlockCompressedTexture : ITexture
    {
        uint BlockWidth { get; }
        uint BlockHeight { get; }
        uint BlockSize { get; }
    }
}
