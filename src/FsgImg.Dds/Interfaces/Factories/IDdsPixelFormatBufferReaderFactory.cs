using FsgImg.Dds.Interfaces.IO;

namespace FsgImg.Dds.Interfaces.Factories
{
    public interface IDdsPixelFormatBufferReaderFactory
    {
        IDdsPixelFormatReader Create(byte[] buffer, int offset, int count);
    }
}
