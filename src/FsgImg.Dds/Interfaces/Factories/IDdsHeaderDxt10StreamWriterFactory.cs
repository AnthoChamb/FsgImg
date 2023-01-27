using FsgImg.Dds.Interfaces.IO;
using System.IO;

namespace FsgImg.Dds.Interfaces.Factories
{
    public interface IDdsHeaderDxt10StreamWriterFactory
    {
        IDdsHeaderDxt10Writer Create(Stream stream, bool leaveOpen);
    }
}
