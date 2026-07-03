using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.IO;

namespace FsgImg.Gtx.Factories
{
    public class GtxBlockHeaderByteArrayReaderFactory : IGtxBlockHeaderByteArrayReaderFactory
    {
        public IGtxBlockHeaderReader Create(byte[] buffer, int offset, int count)
        {
            return new GtxBlockHeaderByteArrayReader(buffer, offset, count);
        }
    }
}
