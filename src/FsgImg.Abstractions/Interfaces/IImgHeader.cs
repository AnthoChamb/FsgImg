using FsgImg.Abstractions.Enums;

namespace FsgImg.Abstractions.Interfaces
{
    public interface IImgHeader
    {
        ushort Width { get; set; }
        ushort Height { get; set; }
        ushort Depth { get; set; }
        ImgTextureFormat TextureFormat { get; set; }
        ImgGame Game { get; set; }
        ushort MipmapCount { get; set; }
        ImgPlatform Platform { get; set; }
    }
}
