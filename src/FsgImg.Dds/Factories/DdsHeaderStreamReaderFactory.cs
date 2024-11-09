using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.IO;
using System.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsHeaderStreamReaderFactory : IDdsHeaderStreamReaderFactory
    {
        private readonly IDdsHeaderBufferReaderFactory _factory;

        public DdsHeaderStreamReaderFactory(IDdsHeaderBufferReaderFactory factory)
        {
            _factory = factory;
        }

        public IDdsHeaderReader Create(Stream stream, bool leaveOpen)
        {
            return new DdsHeaderStreamReader(stream, _factory, leaveOpen);
        }
    }
}
