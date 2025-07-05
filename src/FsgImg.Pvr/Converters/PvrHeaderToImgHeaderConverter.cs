using FsgImg.Abstractions.Enums;
using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Pvr.Abstractions.Interfaces;
using FsgImg.Pvr.Abstractions.Interfaces.Converters;

namespace FsgImg.Pvr.Converters
{
    public class PvrHeaderToImgHeaderConverter : IPvrHeaderToImgHeaderConverter
    {
        private readonly IImgHeaderFactory _factory;

        public PvrHeaderToImgHeaderConverter(IImgHeaderFactory factory)
        {
            _factory = factory;
        }

        public IImgHeader ConvertFrom(IPvrHeader pvrHeader)
        {
            return _factory.Create((ushort)pvrHeader.Width,
                                   (ushort)pvrHeader.Height,
                                   (ushort)pvrHeader.Depth,
                                   (ushort)pvrHeader.Width,
                                   ImgTextureFormat.Unknown,
                                   0,
                                   ImgGame.MobileGhl,
                                   (ushort)pvrHeader.MipmapCount,
                                   ImgPlatform.IOs);
        }
    }
}
