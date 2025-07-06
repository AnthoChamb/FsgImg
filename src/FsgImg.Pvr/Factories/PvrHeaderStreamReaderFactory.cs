using FsgImg.Pvr.Abstractions.Interfaces.Factories;
using FsgImg.Pvr.Abstractions.Interfaces.IO;
using FsgImg.Pvr.IO;
using System.IO;

namespace FsgImg.Pvr.Factories
{
    public class PvrHeaderStreamReaderFactory : IPvrHeaderStreamReaderFactory
    {
        private readonly IPvrHeaderByteArrayReaderFactory _factory;

        public PvrHeaderStreamReaderFactory(IPvrHeaderByteArrayReaderFactory factory)
        {
            _factory = factory;
        }

        public IPvrHeaderReader Create(Stream stream, bool leaveOpen)
        {
            return new PvrHeaderStreamReader(stream, _factory, leaveOpen);
        }
    }
}
