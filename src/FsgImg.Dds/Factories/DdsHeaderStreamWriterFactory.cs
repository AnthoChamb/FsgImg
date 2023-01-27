using FsgImg.Dds.Interfaces.Factories;
using FsgImg.Dds.Interfaces.IO;
using FsgImg.Dds.IO;
using System.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsHeaderStreamWriterFactory : IDdsHeaderStreamWriterFactory
    {
        private readonly IDdsHeaderBufferWriterFactory _factory;

        public DdsHeaderStreamWriterFactory(IDdsHeaderBufferWriterFactory factory)
        {
            _factory = factory;
        }

        public IDdsHeaderWriter Create(Stream stream, bool leaveOpen)
        {
            return new DdsHeaderStreamWriter(stream, _factory, leaveOpen);
        }
    }
}
