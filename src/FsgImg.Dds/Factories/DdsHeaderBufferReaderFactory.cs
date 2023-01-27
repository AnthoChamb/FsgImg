using FsgImg.Dds.Interfaces.Factories;
using FsgImg.Dds.Interfaces.IO;
using FsgImg.Dds.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsHeaderBufferReaderFactory : IDdsHeaderBufferReaderFactory
    {
        private readonly IDdsPixelFormatBufferReaderFactory _factory;

        public DdsHeaderBufferReaderFactory(IDdsPixelFormatBufferReaderFactory factory)
        {
            _factory = factory;
        }

        public IDdsHeaderReader Create(byte[] buffer, int offset, int count)
        {
            return new DdsHeaderBufferReader(buffer, _factory, offset, count);
        }
    }
}
