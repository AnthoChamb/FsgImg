using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.IO;

namespace FsgImg.Gtx.Factories
{
    public class Gx2SurfaceByteArrayWriterFactory : IGx2SurfaceByteArrayWriterFactory
    {
        public IGx2SurfaceWriter Create(byte[] buffer, int offset, int count)
        {
            return new Gx2SurfaceByteArrayWriter(buffer, offset, count);
        }
    }
}
