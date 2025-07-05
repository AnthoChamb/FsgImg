using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.IO;
using System.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsHeaderDxt10StreamReaderFactory : IDdsHeaderDxt10StreamReaderFactory
    {
        private readonly IDdsHeaderDxt10ByteArrayReaderFactory _factory;

        public DdsHeaderDxt10StreamReaderFactory(IDdsHeaderDxt10ByteArrayReaderFactory factory)
        {
            _factory = factory;
        }

        public IDdsHeaderDxt10Reader Create(Stream stream, bool leaveOpen)
        {
            return new DdsHeaderDxt10StreamReader(stream, _factory, leaveOpen);
        }
    }
}
