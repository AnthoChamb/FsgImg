using FsgImg.Dds.Abstractions.Interfaces.Converters;
using System.IO;

namespace FsgImg.Dds.Abstractions.Interfaces.Factories
{
    public interface IDdsToImgStreamConverterFactory
    {
        IDdsToImgConverter Create(Stream inputStream, Stream outputStream, bool leaveOpen);
    }
}
