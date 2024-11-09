using FsgImg.Abstractions.Enums;
using FsgImg.Abstractions.Interfaces;

namespace FsgImg
{
    public class ImgHeader : IImgHeader
    {
        public ushort Width { get; set; }
        public ushort Height { get; set; }
        public ushort Depth { get; set; } = 1;
        public ImgTextureFormat TextureFormat { get; set; }
        public ImgGame Game { get; set; }
        public ushort MipmapCount { get; set; } = 1;
        public ImgPlatform Platform { get; set; }
    }
}
