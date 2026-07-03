using FsgImg.Gtx.Abstractions.Interfaces.IO;

namespace FsgImg.Gtx.Abstractions.Interfaces.Factories
{
    public interface IGx2SurfaceByteArrayWriterFactory
    {
        IGx2SurfaceWriter Create(byte[] buffer, int offset, int count);
    }
}
