using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.IO;
using System.IO;

namespace FsgImg.Gtx.Factories
{
    public class GtxBlockHeaderStreamWriterFactory : IGtxBlockHeaderStreamWriterFactory
    {
        private readonly IGtxBlockHeaderByteArrayWriterFactory _factory;

        public GtxBlockHeaderStreamWriterFactory(IGtxBlockHeaderByteArrayWriterFactory factory)
        {
            _factory = factory;
        }

        public IGtxBlockHeaderWriter Create(Stream stream, bool leaveOpen)
        {
            return new GtxBlockHeaderStreamWriter(stream, _factory, leaveOpen);
        }
    }
}
