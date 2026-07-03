using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.IO;

namespace FsgImg.Gtx.Factories
{
    public class Gfx2HeaderByteArrayWriterFactory : IGfx2HeaderByteArrayWriterFactory
    {
        public IGfx2HeaderWriter Create(byte[] buffer, int offset, int count)
        {
            return new Gfx2HeaderByteArrayWriter(buffer, offset, count);
        }
    }
}
