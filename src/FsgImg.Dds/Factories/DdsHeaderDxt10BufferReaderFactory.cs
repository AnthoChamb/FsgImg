using FsgImg.Dds.Interfaces.Factories;
using FsgImg.Dds.Interfaces.IO;
using FsgImg.Dds.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsHeaderDxt10BufferReaderFactory : IDdsHeaderDxt10BufferReaderFactory
    {
        public IDdsHeaderDxt10Reader Create(byte[] buffer, int offset, int count)
        {
            return new DdsHeaderDxt10BufferReader(buffer, offset, count);
        }
    }
}
