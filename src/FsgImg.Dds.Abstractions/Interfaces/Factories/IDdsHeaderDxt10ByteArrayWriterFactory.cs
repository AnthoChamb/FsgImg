using FsgImg.Dds.Abstractions.Interfaces.IO;

namespace FsgImg.Dds.Abstractions.Interfaces.Factories
{
    public interface IDdsHeaderDxt10ByteArrayWriterFactory
    {
        IDdsHeaderDxt10Writer Create(byte[] buffer, int offset, int count);
    }
}
