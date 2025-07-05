using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsHeaderByteArrayWriterFactory : IDdsHeaderByteArrayWriterFactory
    {
        private readonly IDdsPixelFormatByteArrayWriterFactory _factory;

        public DdsHeaderByteArrayWriterFactory(IDdsPixelFormatByteArrayWriterFactory factory)
        {
            _factory = factory;
        }

        public IDdsHeaderWriter Create(byte[] buffer, int offset, int count)
        {
            return new DdsHeaderByteArrayWriter(buffer, _factory, offset, count);
        }
    }
}
