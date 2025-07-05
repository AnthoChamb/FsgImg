using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.IO;
using System.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsHeaderDxt10StreamWriterFactory : IDdsHeaderDxt10StreamWriterFactory
    {
        private readonly IDdsHeaderDxt10ByteArrayWriterFactory _factory;

        public DdsHeaderDxt10StreamWriterFactory(IDdsHeaderDxt10ByteArrayWriterFactory factory)
        {
            _factory = factory;
        }

        public IDdsHeaderDxt10Writer Create(Stream stream, bool leaveOpen)
        {
            return new DdsHeaderDxt10StreamWriter(stream, _factory, leaveOpen);
        }
    }
}
