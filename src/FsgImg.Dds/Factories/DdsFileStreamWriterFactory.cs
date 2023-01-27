using FsgImg.Dds.Interfaces.Factories;
using FsgImg.Dds.Interfaces.IO;
using FsgImg.Dds.IO;
using System.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsFileStreamWriterFactory : IDdsFileStreamWriterFactory
    {
        private readonly IDdsHeaderStreamWriterFactory _headerWriterFactory;
        private readonly IDdsHeaderDxt10StreamWriterFactory _headerDxt10WriterFactory;

        public DdsFileStreamWriterFactory(IDdsHeaderStreamWriterFactory headerWriterFactory, IDdsHeaderDxt10StreamWriterFactory headerDxt10WriterFactory)
        {
            _headerWriterFactory = headerWriterFactory;
            _headerDxt10WriterFactory = headerDxt10WriterFactory;
        }

        public IDdsFileWriter Create(Stream stream, bool leaveOpen)
        {
            return new DdsFileStreamWriter(stream, _headerWriterFactory, _headerDxt10WriterFactory, leaveOpen);
        }
    }
}
