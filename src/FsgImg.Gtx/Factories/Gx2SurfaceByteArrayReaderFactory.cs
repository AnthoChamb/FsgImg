using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.IO;

namespace FsgImg.Gtx.Factories
{
    public class Gx2SurfaceByteArrayReaderFactory : IGx2SurfaceByteArrayReaderFactory
    {
        public IGx2SurfaceReader Create(byte[] buffer, int offset, int count)
        {
            return new Gx2SurfaceByteArrayReader(buffer, offset, count);
        }
    }
}
