using FsgImg.Dds.Interfaces.Factories;
using FsgImg.Dds.Interfaces.IO;
using FsgImg.Dds.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsHeaderBufferWriterFactory : IDdsHeaderBufferWriterFactory
    {
        private readonly IDdsPixelFormatBufferWriterFactory _factory;

        public DdsHeaderBufferWriterFactory(IDdsPixelFormatBufferWriterFactory factory)
        {
            _factory = factory;
        }

        public IDdsHeaderWriter Create(byte[] buffer, int offset, int count)
        {
            return new DdsHeaderBufferWriter(buffer, _factory, offset, count);
        }
    }
}
