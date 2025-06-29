using FsgImg.Abstractions.Enums;

namespace FsgImg
{
    public class ImgHeaderOptions
    {
        public ImgHeaderOptions(ImgPlatform platform)
        {
            switch (platform)
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
