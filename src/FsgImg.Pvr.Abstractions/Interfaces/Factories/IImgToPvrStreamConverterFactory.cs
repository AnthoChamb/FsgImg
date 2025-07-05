using FsgImg.Pvr.Abstractions.Interfaces.Converters;
using System.IO;

namespace FsgImg.Pvr.Abstractions.Interfaces.Factories
{
    public interface IImgToPvrStreamConverterFactory
    {
        IImgToPvrConverter Create(Stream inputStream, Stream outputStream, bool leaveOpen);
    }
}
