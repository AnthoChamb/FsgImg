namespace FsgImg.Abstractions.Interfaces
{
    public interface ITexture
    {
        uint Width { get; }
        uint Height { get; }
        uint MipmapCount { get; }
        uint Size { get; }
        bool IsUncompressed { get; }
    }
}
