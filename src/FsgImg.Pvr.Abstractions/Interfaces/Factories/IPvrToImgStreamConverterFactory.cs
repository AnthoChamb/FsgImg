using FsgImg.Pvr.Abstractions.Interfaces.Converters;
using System.IO;

namespace FsgImg.Pvr.Abstractions.Interfaces.Factories
{
    public interface IPvrToImgStreamConverterFactory
    {
        IPvrToImgConverter Create(Stream inputStream, Stream outputStream, bool leaveOpen);
    }
}
