using FsgImg.Abstractions.Enums;
using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.Factories;

namespace FsgImg.Factories
{
    public class ImgHeaderFactory : IImgHeaderFactory
    {
        public IImgHeader Create(ushort width,
                                 ushort height,
                                 ushort depth,
                                 ushort pitch,
                                 ImgTextureFormat textureFormat,
                                 ushort bcAlpha,
                                 ImgGame game,
                                 ushort mipmapCount,
                                 ImgPlatform platform)
        {
            return new ImgHeader
            {
                Width = width,
                Height = height,
                Depth = depth,
                Pitch = pitch,
                TextureFormat = textureFormat,
                BcAlpha = bcAlpha,
                Game = game,
                MipmapCount = mipmapCount,
                Platform = platform
            };
        }
    }
}
