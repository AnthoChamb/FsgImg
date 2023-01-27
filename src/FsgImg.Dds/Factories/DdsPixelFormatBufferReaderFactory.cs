using FsgImg.Dds.Interfaces.Factories;
using FsgImg.Dds.Interfaces.IO;
using FsgImg.Dds.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsPixelFormatBufferReaderFactory : IDdsPixelFormatBufferReaderFactory
    {
        public IDdsPixelFormatReader Create(byte[] buffer, int offset, int count)
        {
            return new DdsPixelFormatBufferReader(buffer, offset, count);
        }
    }
}
