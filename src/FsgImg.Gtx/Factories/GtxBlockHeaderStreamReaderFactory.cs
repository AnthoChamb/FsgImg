using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.IO;
using System.IO;

namespace FsgImg.Gtx.Factories
{
    public class GtxBlockHeaderStreamReaderFactory : IGtxBlockHeaderStreamReaderFactory
    {
        private readonly IGtxBlockHeaderByteArrayReaderFactory _factory;

        public GtxBlockHeaderStreamReaderFactory(IGtxBlockHeaderByteArrayReaderFactory factory)
        {
            _factory = factory;
        }

        public IGtxBlockHeaderReader Create(Stream stream, bool leaveOpen)
        {
            return new GtxBlockHeaderStreamReader(stream, _factory, leaveOpen);
        }
    }
}
