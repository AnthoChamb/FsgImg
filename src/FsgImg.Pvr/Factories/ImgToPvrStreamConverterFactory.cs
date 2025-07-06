using FsgImg.Pvr.Abstractions.Interfaces.Converters;
using FsgImg.Pvr.Abstractions.Interfaces.Factories;
using FsgImg.Pvr.Converters;
using System.IO;

namespace FsgImg.Pvr.Factories
{
    public class ImgToPvrStreamConverterFactory : IImgToPvrStreamConverterFactory
    {
        public IImgToPvrConverter Create(Stream inputStream, Stream outputStream, bool leaveOpen)
        {
            return new ImgToPvrStreamConverter(inputStream, outputStream, leaveOpen);
        }
    }
}
