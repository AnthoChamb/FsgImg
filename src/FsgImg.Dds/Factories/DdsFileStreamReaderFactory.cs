using FsgImg.Dds.Interfaces.Factories;
using FsgImg.Dds.Interfaces.IO;
using FsgImg.Dds.IO;
using System.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsFileStreamReaderFactory : IDdsFileStreamReaderFactory
    {
        private readonly IDdsHeaderStreamReaderFactory _headerReaderFactory;
        private readonly IDdsHeaderDxt10StreamReaderFactory _headerDxt10ReaderFactory;

        public DdsFileStreamReaderFactory(IDdsHeaderStreamReaderFactory headerReaderFactory, IDdsHeaderDxt10StreamReaderFactory headerDxt10ReaderFactory)
        {
            _headerReaderFactory = headerReaderFactory;
            _headerDxt10ReaderFactory = headerDxt10ReaderFactory;
        }

        public IDdsFileReader Create(Stream stream, bool leaveOpen)
        {
            return new DdsFileStreamReader(stream, _headerReaderFactory, _headerDxt10ReaderFactory, leaveOpen);
        }
    }
}
