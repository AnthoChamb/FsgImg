using FsgImg.Core.Enums;
using FsgImg.Core.Interfaces;

namespace FsgImg.Core
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
