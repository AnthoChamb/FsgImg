namespace FsgImg.Abstractions.Interfaces
{
    public interface ITexture
    {
        uint Width { get; }
        uint Height { get; }
        uint MipmapCount { get; }
        uint BitsPerPixel { get; }
        uint Size { get; }
        bool IsUncompressed { get; }
    }
}
