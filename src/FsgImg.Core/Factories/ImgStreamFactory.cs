using FsgImg.Core.Enums;
using FsgImg.Core.Interfaces;
using FsgImg.Core.Interfaces.Factories;
using FsgImg.IO;
using System.IO;

namespace FsgImg.Core.Factories
{
    public class ImgStreamFactory : IImgStreamFactory
    {
        public Stream Create(Stream stream, IImgHeader imgHeader)
        {
            switch (imgHeader.TextureFormat)
            {
                case ImgTextureFormat.DdsRgba8:
                    // Reverse Rgba to Abgr
                    stream = new BufferTransformStream(stream, new ReverseIntBufferTransform());
                    break;
            }

            switch (imgHeader.Platform)
            {
                case ImgPlatform.Xbox360:
                    stream = new BufferTransformStream(stream, new ReverseShortBufferTransform());
                    break;
            }

            return stream;
        }
    }
}
