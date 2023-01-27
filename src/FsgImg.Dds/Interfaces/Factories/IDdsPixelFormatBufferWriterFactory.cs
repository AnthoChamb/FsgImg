using FsgImg.Dds.Interfaces.IO;

namespace FsgImg.Dds.Interfaces.Factories
{
    public interface IDdsPixelFormatBufferWriterFactory
    {
        IDdsPixelFormatWriter Create(byte[] buffer, int offset, int count);
    }
}
