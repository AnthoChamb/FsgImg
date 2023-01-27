using FsgImg.Dds.Interfaces.IO;

namespace FsgImg.Dds.Interfaces.Factories
{
    public interface IDdsHeaderDxt10BufferWriterFactory
    {
        IDdsHeaderDxt10Writer Create(byte[] buffer, int offset, int count);
    }
}
