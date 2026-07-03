using FsgImg.Gtx.Abstractions.Interfaces.IO;

namespace FsgImg.Gtx.Abstractions.Interfaces.Factories
{
    public interface IGtxBlockHeaderByteArrayReaderFactory
    {
        IGtxBlockHeaderReader Create(byte[] buffer, int offset, int count);
    }
}
