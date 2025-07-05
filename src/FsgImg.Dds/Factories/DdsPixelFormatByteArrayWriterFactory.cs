using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsPixelFormatByteArrayWriterFactory : IDdsPixelFormatByteArrayWriterFactory
    {
        public IDdsPixelFormatWriter Create(byte[] buffer, int offset, int count)
        {
            return new DdsPixelFormatByteArrayWriter(buffer, offset, count);
        }
    }
}
