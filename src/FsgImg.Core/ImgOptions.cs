using FsgImg.Core.Enums;
using FsgImg.Core.Interfaces;

namespace FsgImg.Core
{
    public class ImgOptions
    {
        public ImgOptions(IImgHeader imgHeader)
        {
            IsLittleEndian = IncludeBaseLevelMipmap = imgHeader.Platform == ImgPlatform.IOs;
        }

        public bool IsLittleEndian { get; }
        public bool IncludeBaseLevelMipmap { get; }
    }
}
