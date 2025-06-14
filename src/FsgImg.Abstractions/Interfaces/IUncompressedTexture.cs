namespace FsgImg.Abstractions.Interfaces
{
    public interface IUncompressedTexture : ITexture
    {
        uint BitsPerPixel { get; }
    }
}
