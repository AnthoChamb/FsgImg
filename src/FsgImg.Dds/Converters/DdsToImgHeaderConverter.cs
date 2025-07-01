using FsgImg.Abstractions.Enums;
using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Enums;
using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.Converters;
using FsgImg.Dds.Abstractions.Options;
using FsgImg.Dds.Exceptions;

namespace FsgImg.Dds.Converters
{
    public class DdsToImgHeaderConverter : IDdsToImgHeaderConverter
    {
        private readonly IImgHeaderFactory _factory;

        public DdsToImgHeaderConverter(IImgHeaderFactory factory)
        {
            _factory = factory;
        }

        public IImgHeader ConvertFrom(IDds dds, ConvertFromOptions options)
        {
            var ddsHeader = dds.Header;
            var ddsFourCc = ddsHeader.PixelFormat.FourCc;

            ImgTextureFormat textureFormat;
            ushort bcAlpha;
            switch (ddsFourCc)
            {
                case DdsFourCc.Dxt1:
                    textureFormat = ImgTextureFormat.Bc1;
                    bcAlpha = 0;
                    break;
                case DdsFourCc.Dxt3:
                    textureFormat = ImgTextureFormat.Bc2;
                    bcAlpha = 1;
                    break;
                case DdsFourCc.Dxt5:
                    textureFormat = ImgTextureFormat.Bc3;
                    bcAlpha = 255;
                    break;
                case DdsFourCc.Dx10:
                    var dxgiFormat = dds.HeaderDxt10.DxgiFormat;
                    switch (dxgiFormat)
                    {
                        case DxgiFormat.R8G8B8A8Typeless:
                        case DxgiFormat.R8G8B8A8UNorm:
                        case DxgiFormat.R8G8B8A8UNormSrgb:
                        case DxgiFormat.R8G8B8A8UInt:
                        case DxgiFormat.R8G8B8A8SNorm:
                        case DxgiFormat.R8G8B8A8SInt:
                            textureFormat = ImgTextureFormat.Rgba8;
                            bcAlpha = 0;
                            break;
                        case DxgiFormat.BC1Typeless:
                        case DxgiFormat.BC1UNorm:
                        case DxgiFormat.BC1UNormSrgb:
                            textureFormat = ImgTextureFormat.Bc1;
                            bcAlpha = 0;
                            break;
                        case DxgiFormat.BC2Typeless:
                        case DxgiFormat.BC2UNorm:
                        case DxgiFormat.BC2UNormSrgb:
                            textureFormat = ImgTextureFormat.Bc2;
                            bcAlpha = 1;
                            break;
                        case DxgiFormat.BC3Typeless:
                        case DxgiFormat.BC3UNorm:
                        case DxgiFormat.BC3UNormSrgb:
                            textureFormat = ImgTextureFormat.Bc3;
                            bcAlpha = 255;
                            break;
                        default:
                            return InvalidDxgiFormatException.Throw<IImgHeader>(dxgiFormat);
                    }
                    break;
                default:
                    return InvalidDdsPixelFormatFourCcException.Throw<IImgHeader>(ddsFourCc);
            }

            return _factory.Create((ushort)ddsHeader.Width,
                                   (ushort)ddsHeader.Height,
                                   (ushort)ddsHeader.Depth,
                                   (ushort)ddsHeader.Width,
                                   textureFormat,
                                   bcAlpha,
                                   (ImgGame)options.Game,
                                   (ushort)ddsHeader.MipmapCount,
                                   (ImgPlatform)options.Platform);
        }
    }
}
