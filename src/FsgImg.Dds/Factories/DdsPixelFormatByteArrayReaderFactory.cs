using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsPixelFormatByteArrayReaderFactory : IDdsPixelFormatByteArrayReaderFactory
    {
        public IDdsPixelFormatReader Create(byte[] buffer, int offset, int count)
        {
            return new DdsPixelFormatByteArrayReader(buffer, offset, count);
        }
    }
}
