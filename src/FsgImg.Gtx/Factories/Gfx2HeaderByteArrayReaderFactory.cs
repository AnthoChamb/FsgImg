using FsgImg.Gtx.Abstractions.Interfaces.Factories;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.IO;

namespace FsgImg.Gtx.Factories
{
    public class Gfx2HeaderByteArrayReaderFactory : IGfx2HeaderByteArrayReaderFactory
    {
        public IGfx2HeaderReader Create(byte[] buffer, int offset, int count)
        {
            return new Gfx2HeaderByteArrayReader(buffer, offset, count);
        }
    }
}
