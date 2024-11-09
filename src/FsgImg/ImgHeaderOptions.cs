using FsgImg.Abstractions.Enums;
using FsgImg.Abstractions.Interfaces;

namespace FsgImg
{
    public class ImgHeaderOptions
    {
        public ImgHeaderOptions(IImgHeader imgHeader)
        {
            IsLittleEndian = IncludesBaseLevelMipmap = imgHeader.Platform == ImgPlatform.IOs;
        }

        public bool IsLittleEndian { get; }
        public bool IncludesBaseLevelMipmap { get; }
    }
}
