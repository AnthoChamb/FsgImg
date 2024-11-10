using FsgImg.Abstractions.Enums;
using FsgImg.Abstractions.Interfaces;

namespace FsgImg
{
    public class ImgHeaderOptions
    {
        public ImgHeaderOptions(IImgHeader imgHeader)
        {
            switch (imgHeader.Platform)
            {
                case ImgPlatform.Pc:
                case ImgPlatform.XboxOne:
                    IsLittleEndian = true;
                    break;
                case ImgPlatform.IOs:
                    IsLittleEndian = true;
                    IncludesBaseLevelMipmap = true;
                    break;
            }
        }

        public bool IsLittleEndian { get; }
        public bool IncludesBaseLevelMipmap { get; }
    }
}
