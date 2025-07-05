using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsHeaderDxt10ByteArrayReaderFactory : IDdsHeaderDxt10ByteArrayReaderFactory
    {
        public IDdsHeaderDxt10Reader Create(byte[] buffer, int offset, int count)
        {
            return new DdsHeaderDxt10ByteArrayReader(buffer, offset, count);
        }
    }
}
