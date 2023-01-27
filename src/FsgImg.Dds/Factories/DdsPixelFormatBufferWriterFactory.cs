using FsgImg.Dds.Interfaces.Factories;
using FsgImg.Dds.Interfaces.IO;
using FsgImg.Dds.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsPixelFormatBufferWriterFactory : IDdsPixelFormatBufferWriterFactory
    {
        public IDdsPixelFormatWriter Create(byte[] buffer, int offset, int count)
        {
            return new DdsPixelFormatBufferWriter(buffer, offset, count);
        }
    }
}
