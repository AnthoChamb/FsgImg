using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.IO;
using System.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsStreamReaderFactory : IDdsStreamReaderFactory
    {
        private readonly IDdsHeaderStreamReaderFactory _headerReaderFactory;
        private readonly IDdsHeaderDxt10StreamReaderFactory _headerDxt10ReaderFactory;

        public DdsStreamReaderFactory(IDdsHeaderStreamReaderFactory headerReaderFactory, IDdsHeaderDxt10StreamReaderFactory headerDxt10ReaderFactory)
        {
            _headerReaderFactory = headerReaderFactory;
            _headerDxt10ReaderFactory = headerDxt10ReaderFactory;
        }

        public IDdsReader Create(Stream stream, bool leaveOpen)
        {
            return new DdsStreamReader(stream, _headerReaderFactory, _headerDxt10ReaderFactory, leaveOpen);
        }
    }
}
