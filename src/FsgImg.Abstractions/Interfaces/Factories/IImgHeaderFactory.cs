using FsgImg.Abstractions.Enums;

namespace FsgImg.Abstractions.Interfaces.Factories
{
    public interface IImgHeaderFactory
    {
        IImgHeader Create(ushort width,
                          ushort height,
                          ushort depth,
                          ushort pitch,
                          ImgTextureFormat textureFormat,
                          ushort bcAlpha,
                          ImgGame game,
                          ushort mipmapCount,
                          ImgPlatform platform);
    }
}
