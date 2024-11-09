using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using FsgImg.Dds.IO;
using System.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsStreamWriterFactory : IDdsStreamWriterFactory
    {
        private readonly IDdsHeaderStreamWriterFactory _headerWriterFactory;
        private readonly IDdsHeaderDxt10StreamWriterFactory _headerDxt10WriterFactory;

        public DdsStreamWriterFactory(IDdsHeaderStreamWriterFactory headerWriterFactory, IDdsHeaderDxt10StreamWriterFactory headerDxt10WriterFactory)
        {
            _headerWriterFactory = headerWriterFactory;
            _headerDxt10WriterFactory = headerDxt10WriterFactory;
        }

        public IDdsWriter Create(Stream stream, bool leaveOpen)
        {
            return new DdsStreamWriter(stream, _headerWriterFactory, _headerDxt10WriterFactory, leaveOpen);
        }
    }
}
