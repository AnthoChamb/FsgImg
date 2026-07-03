using FsgImg.Gtx.Abstractions.Interfaces.IO;

namespace FsgImg.Gtx.Abstractions.Interfaces.Factories
{
    public interface IGx2SurfaceByteArrayReaderFactory
    {
        IGx2SurfaceReader Create(byte[] buffer, int offset, int count);
    }
}
