using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsHeaderDxt10ByteArrayWriterFactory : IDdsHeaderDxt10ByteArrayWriterFactory
    {
        public IDdsHeaderDxt10Writer Create(byte[] buffer, int offset, int count)
        {
            return new DdsHeaderDxt10ByteArrayWriter(buffer, offset, count);
        }
    }
}
