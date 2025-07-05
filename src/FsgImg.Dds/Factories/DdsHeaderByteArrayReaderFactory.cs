using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsHeaderByteArrayReaderFactory : IDdsHeaderByteArrayReaderFactory
    {
        private readonly IDdsPixelFormatByteArrayReaderFactory _factory;

        public DdsHeaderByteArrayReaderFactory(IDdsPixelFormatByteArrayReaderFactory factory)
        {
            _factory = factory;
        }

        public IDdsHeaderReader Create(byte[] buffer, int offset, int count)
        {
            return new DdsHeaderByteArrayReader(buffer, _factory, offset, count);
        }
    }
}
