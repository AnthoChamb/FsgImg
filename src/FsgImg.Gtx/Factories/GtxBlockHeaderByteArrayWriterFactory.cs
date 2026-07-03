using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.IO;

namespace FsgImg.Gtx.Factories
{
    public class GtxBlockHeaderByteArrayWriterFactory : IGtxBlockHeaderByteArrayWriterFactory
    {
        public IGtxBlockHeaderWriter Create(byte[] buffer, int offset, int count)
        {
            return new GtxBlockHeaderByteArrayWriter(buffer, offset, count);
        }
    }
}
