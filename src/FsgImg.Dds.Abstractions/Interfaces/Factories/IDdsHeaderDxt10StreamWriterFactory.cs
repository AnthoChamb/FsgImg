using FsgImg.Dds.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgImg.Dds.Abstractions.Interfaces.Factories
{
    public interface IDdsHeaderDxt10StreamWriterFactory
    {
        IDdsHeaderDxt10Writer Create(Stream stream, bool leaveOpen);
    }
}
