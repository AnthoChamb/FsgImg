using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.IO;
using System.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsHeaderStreamWriterFactory : IDdsHeaderStreamWriterFactory
    {
        private readonly IDdsHeaderByteArrayWriterFactory _factory;

        public DdsHeaderStreamWriterFactory(IDdsHeaderByteArrayWriterFactory factory)
        {
            _factory = factory;
        }

        public IDdsHeaderWriter Create(Stream stream, bool leaveOpen)
        {
            return new DdsHeaderStreamWriter(stream, _factory, leaveOpen);
        }
    }
}
