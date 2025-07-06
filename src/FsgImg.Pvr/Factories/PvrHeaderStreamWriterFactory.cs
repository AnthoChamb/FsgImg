using FsgImg.Pvr.Abstractions.Interfaces.Factories;
using FsgImg.Pvr.Abstractions.Interfaces.IO;
using FsgImg.Pvr.IO;
using System.IO;

namespace FsgImg.Pvr.Factories
{
    public class PvrHeaderStreamWriterFactory : IPvrHeaderStreamWriterFactory
    {
        private readonly IPvrHeaderByteArrayWriterFactory _factory;

        public PvrHeaderStreamWriterFactory(IPvrHeaderByteArrayWriterFactory factory)
        {
            _factory = factory;
        }

        public IPvrHeaderWriter Create(Stream stream, bool leaveOpen)
        {
            return new PvrHeaderStreamWriter(stream, _factory, leaveOpen);
        }
    }
}
