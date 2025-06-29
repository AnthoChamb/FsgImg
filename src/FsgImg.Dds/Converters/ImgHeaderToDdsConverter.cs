using FsgImg.Abstractions.Enums;
using FsgImg.Abstractions.Exceptions;
using FsgImg.Abstractions.Interfaces;
using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions;
using FsgImg.Dds.Abstractions.Enums;
using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.Converters;

namespace FsgImg.Dds.Converters
{
    public class ImgHeaderToDdsConverter : IImgHeaderToDdsConverter
    {
        private readonly ITextureFactory _factory;

        public ImgHeaderToDdsConverter(ITextureFactory factory)
        {
            _factory = factory;
        }

        public IDds ConvertTo(IImgHeader imgHeader)
        {
            var height = imgHeader.Height;
            var width = imgHeader.Width;
            var mipmapCount = imgHeader.MipmapCount;

            var dds = new Dds();
            var ddsHeader = new DdsHeader
            {
                Height = height,
                Width = width,
                Depth = imgHeader.Depth,
                MipmapCount = mipmapCount
            };

            DdsFourCc ddsFourCc;
            IDdsTexture ddsTexture;

            switch (imgHeader.TextureFormat)
            {
                case ImgTextureFormat.Bc1:
                    ddsFourCc = DdsFourCc.Dxt1;
                    ddsTexture = new BlockCompressedDdsTexture(
                        _factory.CreateBlockCompressedTexture(width,
                                                              height,
                                                              mipmapCount,
                                                              DdsConstants.DdsBlockWidth,
                                                              DdsConstants.DdsBlockHeight,
                                                              DdsConstants.DdsBc1BlockSize));
                    break;
                case ImgTextureFormat.Bc2:
                    ddsFourCc = DdsFourCc.Dxt3;
                    ddsTexture = new BlockCompressedDdsTexture(
                        _factory.CreateBlockCompressedTexture(width,
                                                              height,
                                                              mipmapCount,
                                                              DdsConstants.DdsBlockWidth,
                                                              DdsConstants.DdsBlockHeight,
                                                              DdsConstants.DdsBc2BlockSize));
                    break;
                case ImgTextureFormat.Bc3:
                    ddsFourCc = DdsFourCc.Dxt5;
                    ddsTexture = new BlockCompressedDdsTexture(
                        _factory.CreateBlockCompressedTexture(width,
                                                              height,
                                                              mipmapCount,
                                                              DdsConstants.DdsBlockWidth,
                                                              DdsConstants.DdsBlockHeight,
                                                              DdsConstants.DdsBc3BlockSize));
                    break;
                case ImgTextureFormat.Rgba8:
                    ddsFourCc = DdsFourCc.Dx10;
                    dds.HeaderDxt10 = new DdsHeaderDxt10
                    {
                        DxgiFormat = DxgiFormat.R8G8B8A8UNorm
                    };
                    ddsTexture = new DdsTexture(
                        _factory.CreateUncompressedTexture(width,
                                                           height,
                                                           mipmapCount,
                                                           32));
                    break;
                default:
                    return InvalidImgTextureFormatException.Throw<IDds>(imgHeader.TextureFormat);
            }

            ddsHeader.PixelFormat = new DdsPixelFormat
            {
                FourCc = ddsFourCc
            };

            if (ddsTexture.IsUncompressed)
            {
                ddsHeader.Flags |= DdsHeaderFlags.Pitch;
                ddsHeader.PitchOrLinearSize = ddsTexture.Pitch;
            }
            else
            {
                ddsHeader.Flags |= DdsHeaderFlags.LinearSize;
                ddsHeader.PitchOrLinearSize = ddsTexture.Size;
            }

            if (mipmapCount > 1)
            {
                ddsHeader.Flags |= DdsHeaderFlags.MipmapCount;
                ddsHeader.Caps |= DdsCapsFlags.Mipmap;
            }

            dds.Header = ddsHeader;
            return dds;
        }
    }
}
